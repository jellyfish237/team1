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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "N_teleport")
        {
            int next_room = ArrayUtility.IndexOf(grid.GetComponent<grid_room_generator>().Grid, collision.gameObject.transform.parent.gameObject.transform.parent.gameObject);
            print(next_room);
            Debug.Log(grid.GetComponent<grid_room_generator>().Grid[3]);
        }
    }
}
