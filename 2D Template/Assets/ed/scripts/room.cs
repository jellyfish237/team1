using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class room : MonoBehaviour
{
    public static Dictionary<int, room> Indicestorooms = new();

    public GameObject[] spawn_points;
    public int given_index;
    public GameObject ghost;
    public GameObject red_ghost;
    public GameObject health_item;
    private int rng;
    public GameObject objects;

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
            }
            else if (rng == 1)
            {
                GameObject new_health_item = Instantiate(health_item, new Vector3(spawn_points[i].transform.position.x, spawn_points[i].transform.position.y, spawn_points[i].transform.position.z), spawn_points[i].transform.rotation);
                new_health_item.transform.parent = objects.transform;
            }
        }
    }
}