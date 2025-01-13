using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class killaura : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GetComponentInParent<keyghost>().attacking_player == false)
            {
                GetComponentInParent<keyghost>().StartSummonCooldown();
            }
        }
    }
}