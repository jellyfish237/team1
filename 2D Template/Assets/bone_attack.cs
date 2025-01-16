using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bone_attack : MonoBehaviour
{
    private bool look_at_player = true;
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject laser;

    void Start()
    {
        StartCoroutine(attack());
    }

    void Update()
    {
        if (look_at_player)
        {
            transform.up = player.transform.position - transform.position;
        }
    }
    public IEnumerator attack()
    {
        yield return new WaitForSeconds(2.0f);
        look_at_player = false;
        laser.SetActive(false);
        rb.AddForce(20 * transform.up, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<player>().StartDamageCooldown();
            player.GetComponent<PlayerHealth>().health -= 8;
        }
    }
}
