using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float maxHP = 100;
    private bool ghostDead = false;
    public float damageSpeed = 50;
    //make ghost take damage only when being chased
    [HideInInspector] public bool isInLight;
    
    void Update()
    {
        if (isInLight)
        {
            health -= Time.deltaTime * damageSpeed;
        }
        if (health <= 0 && !ghostDead)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
