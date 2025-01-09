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
    public Camera cam;
    [HideInInspector] public Vector2 currentDi;
    private SpriteRenderer spri;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        spri = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (can_move == true)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();
            rb2d.velocity = moveInput * speed;
            ani.SetFloat("Velocityx", rb2d.velocity.x);
            ani.SetFloat("Velocityy", rb2d.velocity.y);
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
        cam.GetComponent<camera_shake>().StartCoroutine1();
        can_take_damage = false;
        yield return new WaitForSeconds(i_frames);
        can_take_damage = true;
    }
}
