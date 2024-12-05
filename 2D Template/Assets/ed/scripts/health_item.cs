using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_item : MonoBehaviour
{
    public Rigidbody2D RB;
    public int healing = 30;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().health += healing;
            collision.gameObject.GetComponent<PlayerHealth>().health = Mathf.Clamp(collision.gameObject.GetComponent<PlayerHealth>().health, -1, collision.gameObject.GetComponent<PlayerHealth>().maxHP);
            Destroy(gameObject);
        }
    }
}