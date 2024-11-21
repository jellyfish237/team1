using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class notouchbullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private GameObject player;
    private float timer;
    public float time;
    public float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > time)
        {
            Destroy(gameObject);
        }
   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<playerHealth>().health -= damage;
        }
    }
}
