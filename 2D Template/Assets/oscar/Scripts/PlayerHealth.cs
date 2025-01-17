using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHP;
    private bool isDead;
    public ParticleSystem healthParticle;
    private SpriteRenderer spri;
    private Animator ani;
    public GameObject deathUI;
    public GameObject playerUI;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
        isDead = false;
        ani = GetComponent<Animator>();
        spri = GetComponent<SpriteRenderer>();
        deathUI.SetActive(false);
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
            ani.SetBool("isDead", true);
            deathUI.SetActive(true);
            playerUI.SetActive(false);
            GetComponent<SummonItem>().canUseItem = false;
            GetComponent<player>().can_move = false;


        }

    }
    public void healParticle()
    {
        healthParticle.Play();
    }

    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
