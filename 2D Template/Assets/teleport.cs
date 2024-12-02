using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public teleport next_position;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //int index = collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<room>().given_index;
            //Debug.Log(grid.GetComponent<grid_room_generator>().Grid[index]);
            //Debug.Log(grid.GetComponent<grid_room_generator>().Grid[index - 7]);

            transform.position = next_position.transform.position;
        }
    }

}
