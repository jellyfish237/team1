using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public teleport next_position;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<player>().can_teleport == true)
        {
            collision.gameObject.GetComponent<player>().StartTeleportCooldown();
            Debug.Log(collision.gameObject.GetComponent<player>().can_teleport);
            collision.gameObject.transform.position = next_position.transform.position;
        }
    }

}
