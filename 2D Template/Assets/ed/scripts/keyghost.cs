using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyghost : MonoBehaviour
{
    public CircleCollider2D emf5;
    public CircleCollider2D emf4;
    public CircleCollider2D emf3;
    public EnemyHealth enemy_hp;

    void Update()
    {
        if (enemy_hp.GetComponent<EnemyHealth>().health <= 0)
        {
            Debug.Log("spawned a key");
        }
    }
}
