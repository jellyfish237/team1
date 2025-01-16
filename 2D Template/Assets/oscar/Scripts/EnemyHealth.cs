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

    public GameObject particles;


    [SerializeField] FloatingHealthbar healthbar;
    public AnimationClip AnimationClip;


    void Start()
    {
        health = maxHP;
        //health = Random.Range(minHP, maxHP);
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<FloatingHealthbar>();
        //healthbar.UpdateHealthBar(health, maxHP);
    }
    void Update()
    {

        if (isInLight && GetComponent<EnemyMovement>().hasLineOfSight == true)
        {
            takingDamage = true;
            health -= Time.deltaTime * currentMirror.damageSpeed;
            healthbar.UpdateHealthBar(health, maxHP);
            particles.SetActive(true);
        }
        if (!isInLight && takingDamage)
        {
            takingDamage = false;
            GetComponent<EnemyMovement>().StartStunCooldown();
            particles.SetActive(false);
        }
        if (ghostDead == false && health <= 0)
        {
            ghostDead = true;
            RB.velocity = Vector2.zero;
            animator.StopPlayback();
            animator.SetTrigger("Dead");
            StartCoroutine(die());
        }
        if(ghostDead == true)
        {

        }
    }
    IEnumerator die()
    {
        yield return new WaitForSecondsRealtime(AnimationClip.length);
        Destroy(gameObject);
    }
}