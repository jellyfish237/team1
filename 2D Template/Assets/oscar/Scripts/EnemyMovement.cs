using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private float currentSpeed;
    private GameObject player;
    public float timer;
    public float damage;
    public bool canTakeDamage;

    private bool hasLineOfSight = false;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLineOfSight)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, currentSpeed * Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
        //Raycast distance
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        } 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && (other.gameObject.GetComponent<player>().can_take_damage == true))
        {
            other.gameObject.GetComponent<player>().StartDamageCooldown();
            
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            currentSpeed = -speed;
            Invoke("TurnAround", timer);
        }


    }
    private void TurnAround()
    {
        currentSpeed = speed;
    }
}
