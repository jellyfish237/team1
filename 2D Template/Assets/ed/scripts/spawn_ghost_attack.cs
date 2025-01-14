using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_ghost_attack : MonoBehaviour
{
    public GameObject objects;
    public GameObject[] spawn_points;
    public GameObject ghost;
    public GameObject red_ghost;

    public GameObject key_ghost;
    private int rng;

    int max_ghosts = 4;
    void Start()
    {
        objects = GameObject.Find("objects");
        int ghost_limit = max_ghosts - key_ghost.GetComponent<keyghost>().ghosts_nearby;
        Debug.Log(ghost_limit);
        Debug.Log(key_ghost.GetComponent<keyghost>().ghosts_nearby);
        if (ghost_limit > 0)
        {
            for (int i = 0; i < ghost_limit; i++)
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
}