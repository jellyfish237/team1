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
    private bool can_move = true;

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
    }
}
