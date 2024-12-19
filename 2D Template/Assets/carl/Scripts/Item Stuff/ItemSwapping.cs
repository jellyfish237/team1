using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwapping : MonoBehaviour
{
    public ItemClass[] items;
    KeyCode cheat1 = KeyCode.F1;
    KeyCode cheat2 = KeyCode.F2;
    KeyCode cheat3 = KeyCode.F3;
    //Make an array of GameObject prefabs for the mirrors
    //Something to be able to press a trigger or button and swap between those items


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(cheat1))
        {
            GetComponent<SummonItem>().mirror = items[0];
        }
        if (Input.GetKeyDown(cheat2))
        {
            GetComponent<SummonItem>().mirror = items[1];
        }
        if (Input.GetKeyDown(cheat3))
        {
            GetComponent<SummonItem>().mirror = items[2];
        }
    }
}
