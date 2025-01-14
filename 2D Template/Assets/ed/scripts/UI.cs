using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public SummonItem summonitem;
    public PlayerHealth player_HP;
    public UnityEngine.UI.Slider health_bar;
    public UnityEngine.UI.Slider mirror_bar;
    public GameObject fill;
    public GameObject player;
    public GameObject key_ghost;

    public Animator animator;
    void Start()
    {
        key_ghost = GameObject.FindGameObjectWithTag("key_ghost");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player_HP.GetComponent<PlayerHealth>().health == 0)
        {
            fill.SetActive(false);
        }
        health_bar.value = player_HP.GetComponent<PlayerHealth>().health / 100;
        mirror_bar.value = summonitem.GetComponent<SummonItem>().mirrorTime / 5;

        animator.SetFloat("distance", Vector2.Distance(player.transform.position, key_ghost.transform.position));

        if (animator.GetFloat("distance") <= 25f)
        {
            key_ghost.GetComponent<keyghost>().StartAttacking();
        }
    }
}
