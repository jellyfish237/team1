using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class killaura : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ghost"))
        {
            Destroy(collision.gameObject);
        }
    }
}
