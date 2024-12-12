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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player_HP.GetComponent<PlayerHealth>().health == 0)
        {
            fill.SetActive(false);
        }
        health_bar.value = player_HP.GetComponent<PlayerHealth>().health / 100;
        //mirror_bar.value = summonitem.GetComponent<SummonItem>().mirrorTime / 5;
    }
}
