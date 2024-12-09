using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    public GameObject item;
    public GameObject created_item;
    public Transform itempos;
    public GameObject player;
    public bool stops_player_movement = false;
    public SummonItem item_summon;

    void Start()
    {
        StartCoroutine(UseTime());
        Debug.Log("created a " + item);
        created_item = Instantiate(item, itempos.position, Quaternion.identity);
        created_item.transform.up = player.GetComponent<player>().currentDi;
        if (stops_player_movement == true)
        {
            item_summon.GetComponent<SummonItem>().disable_player_move();
        }
    }
    public IEnumerator UseTime()
    {
        print("yes");
        yield return new WaitForSeconds(5.0f);
    }
    public void Delete()
    {
        item_summon.GetComponent<SummonItem>().Delete();
        Destroy(created_item);
        Destroy(this);
    }
}