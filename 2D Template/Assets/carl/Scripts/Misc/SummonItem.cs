using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonItem : MonoBehaviour
{
    public GameObject item;
    public Transform itempos;
    public KeyCode Itemout;
    private GameObject player;
    private GameObject itemInt;
    private bool isItemActive;
    private bool canUseItem = true;
    public float activeTimer = 5;
    public float OriginalTime = 5;
    public float cooldownTime;
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
            if (Input.GetKeyDown(Itemout))
            {
                GetComponent<player>().can_move = false;
                Summon();
            }
            else if (Input.GetKeyUp(Itemout))
            {
                GetComponent<player>().can_move = true;
                Destroy();
                ItemCooldownStart();
            }
        }

        if (itemInt)
        {
            itemInt.transform.position = itempos.position;
            itemInt.transform.up = GetComponent<player>().currentDi;
        }

        if (isItemActive == true)
        {
            activeTimer -= Time.deltaTime;

            if (activeTimer <= 0.0f)
            {
                timerEnded();
                canUseItem = true;
                activeTimer = OriginalTime;
            }
        }

    }
    void Summon()
    {
           itemInt = Instantiate(item, itempos.position, Quaternion.identity);
           isItemActive = true;
        
    }
    void Destroy()
    {
        Destroy(itemInt);
        isItemActive = false;
    }
    public void ItemCooldownStart()
    {
        StartCoroutine(ItemCooldown());
    }
    public IEnumerator ItemCooldown()
    {
        canUseItem = false;
        yield return new WaitForSeconds(cooldownTime);
        canUseItem = true;
    }

    void timerEnded()
    {
        Destroy();
    }
}
