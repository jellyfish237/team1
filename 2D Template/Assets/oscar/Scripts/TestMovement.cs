using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed;
    public KeyCode left, right, up, down;
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
           player.AddForce(Vector3.left * speed);
        }

        if (Input.GetKey(right))
        {
            player.AddForce(Vector3.right * speed);
        }

        if (Input.GetKey(up))
        {
            player.AddForce(Vector3.up * speed);
        }

        if (Input.GetKey(down))
        {
            player.AddForce(Vector3.down * speed);
        }
    }
}
