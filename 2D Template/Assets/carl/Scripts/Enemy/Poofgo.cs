using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poofgo : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float time;
    public float dist = 10;

    private GameObject player;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < dist)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                timer = 0;
                shoot();
            }
        }

    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
