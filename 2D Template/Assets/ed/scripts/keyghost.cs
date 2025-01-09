using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyghost : MonoBehaviour
{
    public EnemyHealth enemy_hp;

    void Update()
    {
        if (enemy_hp.GetComponent<EnemyHealth>().health <= 0)
        {
            Debug.Log("spawned a key");
        }
    }
}
