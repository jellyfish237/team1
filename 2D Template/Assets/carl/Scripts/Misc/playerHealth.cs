using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHP;
    public goui gameManager;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Dead");
            gameManager.gameOver();
            gameObject.SetActive(false);
        }
    }
}
