using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDamage : MonoBehaviour
{
    public float recieved_time = 5.0f;
    public ItemClass item_class;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ghost"))
        {
            other.gameObject.GetComponent<EnemyHealth>().isInLight = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ghost"))
        {
            other.gameObject.GetComponent<EnemyHealth>().isInLight = false;
        }
    }
}