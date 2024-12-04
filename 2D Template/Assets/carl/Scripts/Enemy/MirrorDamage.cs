using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDamage : MonoBehaviour
{
    public float Dmg;
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggereEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("ghost"))
        {
            other.gameObject.GetComponent<EnemyHealth>().isInLight = true;
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("ghost"))
        {
            other.gameObject.GetComponent<EnemyHealth>().isInLight = false;
        }
    }
}
