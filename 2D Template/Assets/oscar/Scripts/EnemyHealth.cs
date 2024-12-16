using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float maxHP = 100;
    public float minHP = 50;
    public float damageSpeed = 50;
    //make ghost take damage only when being chased
    [HideInInspector] public bool isInLight;
    public float pushBack;
    public bool takingDamage;
    void Start()
    {
        health = Random.Range(minHP, maxHP);
    }
    void Update()
    {
        if (isInLight && GetComponent<EnemyMovement>().hasLineOfSight == true)
        {
            takingDamage = true;
            health -= Time.deltaTime * damageSpeed;
        }
        else
        {
            takingDamage = false;
        }
        if (health <= 0)
        {
            GameObject.Destroy(gameObject);

        }
    }
   
}
