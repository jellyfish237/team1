using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // please start defaulting variables here like this   >>   public float variable_name = 10;
    [SerializeField] public float minSpeed = 4;
    [SerializeField] public float maxSpeed = 5;
    private float currentSpeed;
    public float speed;
    private GameObject player;
    public float timer;
    public float damage;
    public bool canTakeDamage;
    private Rigidbody2D RB;
    public LayerMask castLayer;

    private bool repositioning;
    private Vector3 new_position;
    private int rng;

    [HideInInspector] public bool hasLineOfSight = false;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        speed = currentSpeed;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyHealth>().takingDamage == true)
        {
            RB.velocity = (player.transform.position - transform.position).normalized * -GetComponent<EnemyHealth>().pushBack;
        }
        else if (repositioning == true && GetComponent<EnemyHealth>().takingDamage == false)
        {
            RB.velocity = (new_position - transform.position).normalized * currentSpeed;
        }
        else if (hasLineOfSight && repositioning == false && GetComponent<EnemyHealth>().takingDamage == false)
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 1000, castLayer);
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
            timer = Random.Range(0.7f, 1.5f);
            Invoke("TurnAround", timer);
        }


    }
    private void TurnAround()
    {
        currentSpeed = speed;
        repositioning = true;
        rng = Random.Range(0, 2);
        if (rng == 0)
        {
            new_position.x = transform.position.x + Random.Range(-3, -4);
        }  
        if (rng == 1)
        {
            new_position.x = transform.position.x + Random.Range(3, 4);
        }
        rng = Random.Range(0, 2);
        if (rng == 0)
        {
            new_position.y = transform.position.x + Random.Range(-3, -4);
        }
        if (rng == 1)
        {
            new_position.y = transform.position.x + Random.Range(3, 4);
        }
        timer = Random.Range(0.7f, 1.5f);
        Invoke("Restart", timer);
    }
    private void Restart()
    {
        repositioning = false;
    }
}
