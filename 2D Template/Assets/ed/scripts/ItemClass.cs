using System.Collections;
using System.Collections.Generic;
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
        created_item = Instantiate(item, itempos.position, Quaternion.identity);
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        created_item.transform.up = direction;
        if (stops_player_movement == true)
        {
            item_summon.GetComponent<SummonItem>().disable_player_move();
        }
    }
    public IEnumerator UseTime()
    {
        yield return new WaitForSeconds(5.0f);
        Delete();
    }
    public void Delete()
    {
        item_summon.GetComponent<SummonItem>().Delete();
        Destroy(created_item);
        Destroy(this);
    }
}