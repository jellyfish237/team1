using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHP;
    private bool ghostDead;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
        ghostDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !ghostDead)
        {
            Debug.Log("Dead");
        }
    }
}
