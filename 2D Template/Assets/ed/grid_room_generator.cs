using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_room_generator : MonoBehaviour
{
    public GameObject NWSE_BasicRoomPrefab;
    public GameObject NWE_BasicRoomPrefab;
    public GameObject NSE_BasicRoomPrefab;
    public GameObject NWS_BasicRoomPrefab;
    public GameObject WSE_BasicRoomPrefab;
    public GameObject[] Grid;
    public int rng;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(NWSE_BasicRoomPrefab, Grid[0].transform.position, Grid[0].transform.rotation);
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            GameObject new_room = Instantiate(NWSE_BasicRoomPrefab, Grid[1].transform.position, Grid[1].transform.rotation);
            new_room.transform.SetParent(Grid[1].transform, true);
        }
        if (rng == 1)
        {
            Instantiate(WSE_BasicRoomPrefab, Grid[1].transform.position, Grid[1].transform.rotation);
        }
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            Instantiate(NWSE_BasicRoomPrefab, Grid[2].transform.position, Grid[2].transform.rotation);
        }
        if (rng == 1)
        {
            Instantiate(NSE_BasicRoomPrefab, Grid[2].transform.position, Grid[2].transform.rotation);
        }
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            Instantiate(NWSE_BasicRoomPrefab, Grid[3].transform.position, Grid[3].transform.rotation);
        }
        if (rng == 1)
        {
            Instantiate(NWE_BasicRoomPrefab, Grid[3].transform.position, Grid[3].transform.rotation);
        }
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            Instantiate(NWSE_BasicRoomPrefab, Grid[4].transform.position, Grid[4].transform.rotation);
        }
        if (rng == 1)
        {
            Instantiate(NWS_BasicRoomPrefab, Grid[4].transform.position, Grid[4].transform.rotation);
        }
        // ------------------
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
