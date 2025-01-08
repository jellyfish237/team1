using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float maxHP = 100;
    //public float minHP = 50;
    
    //make ghost take damage only when being chased
    [HideInInspector] public bool isInLight;
    [HideInInspector] public MirrorDamage currentMirror;
    public float pushBack;
    public bool takingDamage;
    private Animator animator;
    public float timer;
    private Rigidbody2D RB;
    bool ghostDead = false;
    

    [SerializeField] FloatingHealthBar healthbar;
    

    void Start()
    {
        health = maxHP;
        //health = Random.Range(minHP, maxHP);
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<FloatingHealthBar>();
        healthbar.UpdateHealthBar(health, maxHP);
    }
    void Update()
    {
        
        if (isInLight && GetComponent<EnemyMovement>().hasLineOfSight == true)
        {
            takingDamage = true;
            health -= Time.deltaTime * currentMirror.damageSpeed;
            healthbar.UpdateHealthBar(health, maxHP);
        }
        else
        {
            takingDamage = false;
        }
        if (health <= 0)
        {
            ghostDead = true;
            RB.velocity = Vector2.zero;
            animator.SetTrigger("Dead");
            Invoke("ghostAnimation", timer);
        }
        if (ghostDead == true)
        {
            //hello
        }
    }
    private void ghostAnimation()
    {
        Destroy(gameObject);
    }
   
}
