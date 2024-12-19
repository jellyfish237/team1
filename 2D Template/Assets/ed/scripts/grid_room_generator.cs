using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_room_generator : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] Grid;
    public int rng;

    // Start is called before the first frame update

    private void Start()
    {
        Generate();
    }
    public void Generate()
    {
        foreach (var room1 in room.Indicestorooms)
        {
            Destroy(room1.Value.gameObject);
        }
        room.Indicestorooms.Clear();


        for (int i = 0; i < Grid.Length; i++)
        {
            if (i == 24)
            {
                GameObject new_room = Instantiate(rooms[0], Grid[i].transform.position, Grid[i].transform.rotation);
                new_room.transform.SetParent(Grid[i].transform, true);
                new_room.GetComponent<room>().given_index = i;
                room.Indicestorooms.Add(i, new_room.GetComponent<room>());
            }
            else if (i != 24)
            {
                rng = Random.Range(1, rooms.Length);
                GameObject new_room0 = Instantiate(rooms[rng], Grid[i].transform.position, Grid[i].transform.rotation);
                new_room0.transform.SetParent(Grid[i].transform, true);
                new_room0.GetComponent<room>().given_index = i;
                room.Indicestorooms.Add(i, new_room0.GetComponent<room>());
            }
        }

        //GameObject new_room0 = Instantiate(NWSE_BasicRoomPrefab, Grid[24].transform.position, Grid[24].transform.rotation);
        //new_room0.transform.SetParent(Grid[24].transform, true);
        //new_room0.GetComponent<room>().given_index = 24;
        //room.Indicestorooms.Add(24, new_room0.GetComponent<room>());
        /*
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
        }
        // ------------------

        //GameObject sDoor = FindChild(room.Indicestorooms[17].gameObject, gameObject => gameObject.name == "S_teleport");
        //GameObject nDoor = FindChild(room.Indicestorooms[24].gameObject, gameObject => gameObject.name == "N_teleport");
        //sDoor.GetComponent<teleport>().next_position = nDoor.GetComponent<teleport>();
        //nDoor.GetComponent<teleport>().next_position = sDoor.GetComponent<teleport>();
        */
        foreach (var room1 in room.Indicestorooms)
        {
            Debug.Log("started assigning teleports");
            /// NORTH TO SOUTH
            if (room.Indicestorooms.ContainsKey(room1.Key - 7))
            {
                GameObject nDoor = FindChild(room1.Value.gameObject, gameObject => gameObject.name == "N_teleport");
                GameObject sDoor = FindChild(room.Indicestorooms[room1.Key - 7].gameObject, gameObject => gameObject.name == "S_teleport");
                sDoor.GetComponent<teleport>().next_position = nDoor.GetComponent<teleport>();
                nDoor.GetComponent<teleport>().next_position = sDoor.GetComponent<teleport>();
                Debug.Log("the room: " + room1.Key + "north teleport is connected to the " + (room1.Key - 7) + " south teleport");
            }
            else
            {
                GameObject nDoor = FindChild(room1.Value.gameObject, gameObject => gameObject.name == "N_teleport");
                GameObject sDoor = FindChild(room.Indicestorooms[room1.Key + 42].gameObject, gameObject => gameObject.name == "S_teleport");
                sDoor.GetComponent<teleport>().next_position = nDoor.GetComponent<teleport>();
                nDoor.GetComponent<teleport>().next_position = sDoor.GetComponent<teleport>();
                Debug.Log("the room: " + room1.Key + "north teleport is connected to the " + (room1.Key + 42) + " south teleport");
            }
            /// WEST TO EAST
            /// 
            {
                if (room1.Key != 0 && room1.Key - 1 != 6 && room1.Key - 1 != 13 && room1.Key - 1 != 20 && room1.Key - 1 != 27 && room1.Key - 1 != 34 && room1.Key - 1 != 41)
                {
                    GameObject wDoor = FindChild(room1.Value.gameObject, gameObject => gameObject.name == "W_teleport");
                    GameObject eDoor = FindChild(room.Indicestorooms[room1.Key - 1].gameObject, gameObject => gameObject.name == "E_teleport");
                    eDoor.GetComponent<teleport>().next_position = wDoor.GetComponent<teleport>();
                    wDoor.GetComponent<teleport>().next_position = eDoor.GetComponent<teleport>();
                    Debug.Log("the room: " + room1.Key + "west teleport is connected to the " + (room1.Key - 1) + " east teleport");
                }

                else
                {
                    if (room.Indicestorooms.ContainsKey(room1.Key + 6))
                    {
                        Debug.Log(room1.Key);
                        GameObject wDoor = FindChild(room1.Value.gameObject, gameObject => gameObject.name == "W_teleport");
                        GameObject eDoor = FindChild(room.Indicestorooms[room1.Key + 6].gameObject, gameObject => gameObject.name == "E_teleport");
                        eDoor.GetComponent<teleport>().next_position = wDoor.GetComponent<teleport>();
                        wDoor.GetComponent<teleport>().next_position = eDoor.GetComponent<teleport>();
                        Debug.Log("the room: " + room1.Key + "west teleport is connected to the " + (room1.Key + 6) + " east teleport");
                    }
                }
            }
        }
    }
    

    public GameObject FindChild(GameObject parent, System.Predicate<GameObject> search_children)
    {
        foreach (Transform child in parent.GetComponentsInChildren<Transform>(true))
        {
            if (search_children.Invoke(child.gameObject))
                return child.gameObject;
        }
        return null;
    }
}