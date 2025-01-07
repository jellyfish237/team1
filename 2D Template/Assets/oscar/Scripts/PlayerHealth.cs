using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHP;
    private bool isDead;
    public ParticleSystem healthParticle;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Dead");
  
            
        }
        if (isDead == true)
        {
            //Time.timeScale = 0;
        }
    }
    public void healParticle()
    {
        healthParticle.Play();
    }
}
