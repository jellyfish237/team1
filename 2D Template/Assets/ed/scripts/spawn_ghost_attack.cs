using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_ghost_attack : MonoBehaviour
{
    public GameObject objects;
    public GameObject[] spawn_points;
    public GameObject ghost;
    public GameObject red_ghost;
    private int rng;

    void Start()
    {
        objects = GameObject.Find("objects");
        for (int i = 0; i < spawn_points.Length; i++)
        {
            rng = Random.Range(0, 2);
            if (rng == 0)
            {
                GameObject new_ghost = Instantiate(ghost, new Vector3(spawn_points[i].transform.position.x, spawn_points[i].transform.position.y, spawn_points[i].transform.position.z), transform.rotation);
                new_ghost.transform.parent = objects.transform;
                new_ghost.GetComponent<EnemyMovement>().HijackMovement();
            }
            else if (rng == 1)
            {
                GameObject new_red_ghost = Instantiate(red_ghost, new Vector3(spawn_points[i].transform.position.x, spawn_points[i].transform.position.y, spawn_points[i].transform.position.z), spawn_points[i].transform.rotation);
                new_red_ghost.transform.parent = objects.transform;
                new_red_ghost.GetComponent<EnemyMovement>().HijackMovement();
            }
        }
    }
}