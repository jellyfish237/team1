using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_floor_teleport : MonoBehaviour
{
    public GameObject grid;
    public GameObject objects;
    public bool on_cooldown = false;
    void Start()
    {
        grid = GameObject.Find("grid");
        objects = GameObject.Find("objects");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (collision.gameObject.GetComponent<player>().can_move == true) && (on_cooldown == false))
        {
            StartCoroutine(cooldown());
            collision.transform.position = new Vector3(0, 0, 0);
            objects.GetComponent<object_instances>().DeleteEverything();
            grid.GetComponent<grid_room_generator>().Generate();
        }
    }
    public IEnumerator cooldown()
    {
        on_cooldown = false;
        yield return new WaitForSeconds(2f);
        on_cooldown = true;
    }
}