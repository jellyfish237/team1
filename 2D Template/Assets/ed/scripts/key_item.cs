using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<player>().has_key = true;
            Destroy(gameObject);
        }
    }
}