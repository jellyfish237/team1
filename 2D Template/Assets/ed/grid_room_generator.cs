using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_room_generator : MonoBehaviour
{
    public GameObject RoomPrefab;
    public GameObject[] Grid;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(RoomPrefab, Grid[0].transform.position, Grid[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
