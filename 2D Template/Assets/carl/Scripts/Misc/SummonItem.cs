using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonItem : MonoBehaviour
{
    public GameObject item;
    public Transform itempos;
    public KeyCode Itemout;
    public KeyCode rotateL, rotateR;

    private GameObject player;
    private GameObject itemInt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Itemout))
        {
            GetComponent<newmove>().can_move = false;
            Summon();
        }
        else if (Input.GetKeyUp(Itemout))
        {
            GetComponent<newmove>().can_move = true;
            Destroy();
        }

        if (itemInt)
        {
            itemInt.transform.position = itempos.position;
            itemInt.transform.up = GetComponent<newmove>().currentDi;
        }
    }
    void Summon()
    {
           itemInt = Instantiate(item, itempos.position, Quaternion.identity);
        
    }
    void Destroy()
    {
        Destroy(itemInt);
    }
}
