using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schmovin : MonoBehaviour
{
    public float speed = 10;
    public float jumpheight = 20;
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, jump = KeyCode.Space, god = KeyCode.Y;
    private bool isGrounded;
    private Animator ani;
    private SpriteRenderer spr;

    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            ani.SetBool("isJumping", false);
        }

    }
    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            ani.SetBool("isJumping", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {   //Get gameobject rigidbody and set its veloctiy to be the direction at the provided speed
            _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            spr.flipX = false;

        }
        if (Input.GetKey(right))
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
            spr.flipX = true;
        }
        if (Input.GetKey(up))
        {
            _rb.velocity = Vector2.up * speed;
        }
        if (Input.GetKey(down))
        {
            _rb.velocity = Vector2.down * speed;
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            _rb.velocity = new(_rb.velocity.x, jumpheight);
        }
        if (Input.GetKeyUp(jump))
        {
            _rb.velocity = new(_rb.velocity.x, _rb.velocity.y / 2);
        }
        if (Input.GetKeyDown(god))
        {
            GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
        if (_rb.velocity.x >= 0.1f || _rb.velocity.x <= -0.1f)
        {
            ani.SetBool("isRunning", true);
        }
        else
        {
            ani.SetBool("isRunning", false);
        }
    }
}

