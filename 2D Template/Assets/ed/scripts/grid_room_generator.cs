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
        GameObject new_room0 = Instantiate(NWSE_BasicRoomPrefab, Grid[24].transform.position, Grid[24].transform.rotation);
        new_room0.transform.SetParent(Grid[24].transform, true);
        new_room0.GetComponent<room>().given_index = 24;
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            GameObject new_room = Instantiate(NWSE_BasicRoomPrefab, Grid[17].transform.position, Grid[17].transform.rotation);
            new_room.transform.SetParent(Grid[17].transform, true);
            new_room.GetComponent<room>().given_index = 17;

            room.Indicestorooms.Add(17,new_room.GetComponent<room>());
        }
        if (rng == 1)
        {
            GameObject new_room = Instantiate(WSE_BasicRoomPrefab, Grid[17].transform.position, Grid[17].transform.rotation);
            new_room.transform.SetParent(Grid[17].transform, true);
            new_room.GetComponent<room>().given_index = 17;

            room.Indicestorooms.Add(17, new_room.GetComponent<room>());
        }
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            GameObject new_room = Instantiate(NWSE_BasicRoomPrefab, Grid[23].transform.position, Grid[23].transform.rotation);
            new_room.transform.SetParent(Grid[23].transform, true);
            new_room.GetComponent<room>().given_index = 23;

            room.Indicestorooms.Add(23, new_room.GetComponent<room>());
        }
        if (rng == 1)
        {
            GameObject new_room = Instantiate(NSE_BasicRoomPrefab, Grid[23].transform.position, Grid[23].transform.rotation);
            new_room.transform.SetParent(Grid[23].transform, true);
            new_room.GetComponent<room>().given_index = 23;

            room.Indicestorooms.Add(23, new_room.GetComponent<room>());
        }
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            GameObject new_room = Instantiate(NWSE_BasicRoomPrefab, Grid[31].transform.position, Grid[31].transform.rotation);
            new_room.transform.SetParent(Grid[31].transform, true);
            new_room.GetComponent<room>().given_index = 31;

            room.Indicestorooms.Add(31, new_room.GetComponent<room>());
        }
        if (rng == 1)
        {
            GameObject new_room = Instantiate(NWE_BasicRoomPrefab, Grid[31].transform.position, Grid[31].transform.rotation);
            new_room.transform.SetParent(Grid[31].transform, true);
            new_room.GetComponent<room>().given_index = 31;

            room.Indicestorooms.Add(31, new_room.GetComponent<room>());
        }
        // ------------------
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            GameObject new_room = Instantiate(NWSE_BasicRoomPrefab, Grid[25].transform.position, Grid[25].transform.rotation);
            new_room.transform.SetParent(Grid[25].transform, true);
            new_room.GetComponent<room>().given_index = 25;

            room.Indicestorooms.Add(25, new_room.GetComponent<room>());
        }
        if (rng == 1)
        {
            GameObject new_room = Instantiate(NWS_BasicRoomPrefab, Grid[25].transform.position, Grid[25].transform.rotation);
            new_room.transform.SetParent(Grid[25].transform, true);
            new_room.GetComponent<room>().given_index = 25;

            room.Indicestorooms.Add(25, new_room.GetComponent<room>());

            /*GameObject nDoor = FindChild(new_room1, gameObject => gameObject.name == "N_teleport");
            GameObject sDoor = FindChild(new_room2, gameObject => gameObject.name == "S_teleport");

            nDoor.GetComponent<teleport>().next_position = sDoor.GetComponent<teleport>();
            sDoor.GetComponent<teleport>().next_position = nDoor.GetComponent<teleport>();*/
        }
        // ------------------

    }
    // Update is called once per frame
    void Update()
    {

    }

    public GameObject FindChild(GameObject parent, System.Predicate<GameObject> search_children)
    {
        foreach (Transform child in parent.GetComponentsInChildren<Transform>())
        {
            if (search_children.Invoke(child.gameObject))
                return parent.gameObject;
        }

        return null;
    }
}
