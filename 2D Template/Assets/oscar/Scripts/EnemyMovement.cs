using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
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
    private Rigidbody2D RB;

    private bool reposition;
    private Vector3 new_position;
    private int rng;

    [HideInInspector] public bool hasLineOfSight = false;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpeed = speed;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyHealth>().takingDamage == true)
        {
            RB.velocity = (player.transform.position - transform.position).normalized * -GetComponent<EnemyHealth>().pushBack;
        }
        else if (reposition == true)
        {
            RB.velocity = (new_position - transform.position).normalized * currentSpeed;
        }
        else if (hasLineOfSight && reposition == false)
        {
            RB.velocity = (player.transform.position - transform.position).normalized * currentSpeed;
        }
        else
        {
            RB.velocity = Vector2.zero;
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
        reposition = true;
        rng = Random.Range(0, 2);
        if (rng == 0)
        {
            new_position.x = transform.position.x + Random.Range(-4, -5);
        }  
        if (rng == 1)
        {
            new_position.x = transform.position.x + Random.Range(4, 5);
        }
        rng = Random.Range(0, 2);
        if (rng == 0)
        {
            new_position.y = transform.position.x + Random.Range(-4, -5);
        }
        if (rng == 1)
        {
            new_position.y = transform.position.x + Random.Range(4, 5);
        }
        Invoke("Restart", timer);
    }
    private void Restart()
    {
        reposition = false;
    }
}
