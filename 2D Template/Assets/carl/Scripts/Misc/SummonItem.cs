using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonItem : MonoBehaviour
{
    public ItemClass mirror;
    public Transform itempos;
    public KeyCode Itemout;
    private GameObject player;
    public ItemClass current_item;
    private bool isItemActive;
    private bool canUseItem = true;
    public float activeTimer = 5.0f;
    public float mirrorTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isItemActive = false;
        canUseItem = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUseItem == true)
        {
            if (Input.GetKeyDown(Itemout) && isItemActive == false)
            {
                isItemActive = true;
                Summon(mirror);
            }
            else if (Input.GetKeyUp(Itemout))
            {
                Delete();
            }
        }

        if (current_item)
        {
            current_item.transform.position = itempos.position;
            current_item.transform.up = GetComponent<player>().currentDi;
        }

        if (isItemActive == true && mirrorTime >= 0.0f)
        {
            mirrorTime -= Time.deltaTime;
            mirrorTime = Mathf.Clamp(mirrorTime, 0.0f, 5.0f);
        }
        if (!isItemActive)
        {
            mirrorTime = 5.0f;
        }
        //Debug.Log(mirrorTime);
    }
    void Summon(ItemClass item)
    {
        Debug.Log("player wanted to use a " + item);
        ItemClass new_item = Instantiate(mirror, itempos.position, Quaternion.identity);
        new_item.itempos = itempos;
        new_item.player = player;
        new_item.item_summon = this;
        current_item = new_item;
        isItemActive = true;
    }
    public void Delete()
    {
        Destroy(current_item.GetComponent<ItemClass>().created_item);
        Destroy(current_item);
        isItemActive = false;
        enable_player_move();
        ItemCooldownStart();
    }
    public void ItemCooldownStart()
    {
        StartCoroutine(ItemCooldown());
    }
    public IEnumerator ItemCooldown()
    {
        canUseItem = false;
        yield return new WaitForSeconds(0.25f);
        canUseItem = true;
    }
    public void enable_player_move()
    {
        GetComponent<player>().can_move = true;
    }
    public void disable_player_move()
    {
        GetComponent<player>().can_move = false;
    }
}