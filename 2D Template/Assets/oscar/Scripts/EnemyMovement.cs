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
    public bool canAttack = true;
    private Rigidbody2D RB;
    private Animator animator;
    public LayerMask castLayer;
    private bool repositioning;
    private Vector3 new_position;
    private int rng;
    public int id; //0: normal, 1:red 
    public bool seen_player; //stuns the ghosts at first so you dont get jumped instantly
    public float distance; //prevent ghosts from being able to hurt the player from far away

    [HideInInspector] public bool hasLineOfSight = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        speed = currentSpeed;
        RB = GetComponent<Rigidbody2D>();
        StartWanderCooldown();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyHealth>().health <= 0)
        {
            currentSpeed = 0;
            canAttack = false;
        }
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 1000, castLayer);
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");

            if (!seen_player && hasLineOfSight)
            {
                seen_player = true;
                StartStunCooldown();
            }

            if (!hasLineOfSight)
            {
                seen_player = false;
            }
            if (ray.distance <= 0.6 && hasLineOfSight && canAttack == true)
            {
                StartAttackOrder();
            }
            else if (ray.distance >= 0.6 && hasLineOfSight && canAttack == true)
            {
                StopAllCoroutines();
            }
            distance = ray.distance;
        }
    }

    private void Reposition()
    {
        currentSpeed = speed * 1.2f;
        repositioning = true;
        rng = Random.Range(0, 2);
        if (rng == 0)
        {
            new_position.x = transform.position.x + Random.Range(-6, -8);
        }
        if (rng == 1)
        {
            new_position.x = transform.position.x + Random.Range(6, 8);
        }
        rng = Random.Range(0, 2);
        if (rng == 0)
        {
            new_position.y = transform.position.y + Random.Range(-6, -8);
        }
        if (rng == 1)
        {
            new_position.y = transform.position.y + Random.Range(6, 8);
        }
        timer = Random.Range(0.7f, 1.5f);
        Invoke("Restart", timer);
    }
    public void StartWanderCooldown()
    {
        StartCoroutine(reposition_loop());
    }
    public IEnumerator reposition_loop()
    {
        yield return new WaitForSeconds(Random.Range(10.0f, 15.0f));
        if (hasLineOfSight == false)
        {
            Reposition();
        }
        StartWanderCooldown();
    }
    public void StartStunCooldown()
    {
        StartCoroutine(stun());
    }
    public IEnumerator stun()
    {
        Vector3 orginalPos = transform.localPosition;
        float time = 0.0f;

        while (time < 0.8f)
        {
            float x = Random.Range(-0.1f, 0.1f);
            float y = Random.Range(-0.1f, 0.1f);
            transform.localPosition = new Vector3(orginalPos.x + x, orginalPos.y + y, 0);

            time += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = orginalPos;
    }

    public IEnumerator attack_loop()
    {
        if (id == 0)
        {
            canAttack = false;
            animator.SetTrigger("Attack");
            damage_player(10);
            yield return new WaitForSeconds(0.7f);
            currentSpeed = -speed;
            Invoke("Reposition", timer);

        }
        if (id == 1)
        {
            canAttack = false;
            animator.SetTrigger("Attack");
            damage_player(8);
            yield return new WaitForSeconds(0.5f);
            damage_player(8);
            yield return new WaitForSeconds(0.5f);
            currentSpeed = -speed;
            Invoke("Reposition", timer);

        }
    }

    public void damage_player(int damage)
    {
        if (distance <= 1.0 || distance == 0.0 && canAttack)
        {
            player.GetComponent<player>().StartDamageCooldown();
            player.GetComponent<PlayerHealth>().health -= damage;
        }
    }
    public void StartAttackOrder()
    {
        StartCoroutine(attack_loop());
    }
    private void Restart()
    {
        repositioning = false;
        canAttack = true;
        currentSpeed = speed;
    }

    public void HijackMovement()
    {
        canAttack = false;
        Invoke("Reposition", timer);
    }
}
