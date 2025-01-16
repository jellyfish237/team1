using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDamage : MonoBehaviour
{
    public ItemClass item_class;
    public float damageSpeed = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ghost") || other.gameObject.CompareTag("key_ghost"))
        {
            other.gameObject.GetComponent<EnemyHealth>().currentMirror = this;
            other.gameObject.GetComponent<EnemyHealth>().isInLight = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ghost") || other.gameObject.CompareTag("key_ghost"))
        {
            other.gameObject.GetComponent<EnemyHealth>().isInLight = false;
            other.gameObject.GetComponent<EnemyHealth>().currentMirror = null;
        }
    }
}