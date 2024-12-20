using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public teleport next_position;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (collision.gameObject.GetComponent<player>().can_move == true))
        {
            collision.gameObject.GetComponent<player>().StartTeleportCooldown();
            if (gameObject.name == "N_teleport")
            {
                collision.gameObject.transform.position = new Vector2(next_position.transform.position.x, next_position.transform.position.y + 2f);
            }
            if (gameObject.name == "W_teleport")
            {
                collision.gameObject.transform.position = new Vector2(next_position.transform.position.x - 1.5f, next_position.transform.position.y);
            }
            if (gameObject.name == "S_teleport")
            {
                collision.gameObject.transform.position = new Vector2(next_position.transform.position.x, next_position.transform.position.y - 1f);
            }
            if (gameObject.name == "E_teleport")
            {
                collision.gameObject.transform.position = new Vector2(next_position.transform.position.x + 1.5f, next_position.transform.position.y);

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, next_position.transform.position);
    }
}

