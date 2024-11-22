using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_room_generator : MonoBehaviour
{
    public GameObject NWSE_BasicRoomPrefab;
    public GameObject NWE_BasicRoomPrefab;
    public GameObject[] Grid;
    public int rng;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(NWSE_BasicRoomPrefab, Grid[0].transform.position, Grid[0].transform.rotation);

        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 1)
        {
            Instantiate(NWSE_BasicRoomPrefab, Grid[3].transform.position, Grid[3].transform.rotation);
        }
        if (rng == 2)
        {
            Instantiate(NWE_BasicRoomPrefab, Grid[3].transform.position, Grid[3].transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
