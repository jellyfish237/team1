using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject grid;
    public float speed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public bool can_move = true;
    public bool can_take_damage = true;
    public float i_frames = 0f;
    [HideInInspector] public Vector2 currentDi;

    // Update is called once per frame
    void Update()
    {
        if (can_move == true)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();
            rb2d.velocity = moveInput * speed;
        }
        if (moveInput != Vector2.zero)
        {
            currentDi = moveInput;
        }
        if (can_move == false)
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    public void StartTeleportCooldown()
    {
        StartCoroutine(teleport_cooldown());
    }
    public IEnumerator teleport_cooldown()
    {
        can_move = false;
        yield return new WaitForSeconds(0.1f);
        can_move = true;
    }
    //--------------------------------------
    public void StartDamageCooldown()
    {
        StartCoroutine(damage_cooldown());
    }
    public IEnumerator damage_cooldown()
    {
        can_take_damage = false;
        yield return new WaitForSeconds(i_frames);
        can_take_damage = true;
    }
}
