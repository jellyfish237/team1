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
    private bool isItemActive = false;
    private bool canUseItem = true;
    public float activeTimer = 5.0f;
    public float mirrorTime = 5.0f;
    IEnumerator co;
    private SpriteRenderer spri;
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isItemActive = false;
        canUseItem = true;
        ani = GetComponent<Animator>();
        spri = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isItemActive == false && mirrorTime != 0.0f)
        {
            StopAllCoroutines();
            isItemActive = true;
            Summon(mirror);
            ani.SetBool("Mirror", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Delete();
            ani.SetBool("Mirror", false);
        }

        if (current_item)
        {
            current_item.transform.position = itempos.position;
            current_item.transform.up = GetComponent<player>().currentDi;
            Vector2 mousePos = Input.mousePosition;
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 Difference = mouseWorldPos - transform.position;
            ani.SetFloat("Posx", mouseWorldPos.x);
            ani.SetFloat("Posy", mouseWorldPos.y);
        }

        if (isItemActive == true && mirrorTime >= 0.0f)
        {
            mirrorTime -= Time.deltaTime;
            mirrorTime = Mathf.Clamp(mirrorTime, 0.0f, 5.0f);
            if (mirrorTime <= 0.0f)
            {
                Delete();
            }
        }
        if (!isItemActive && canUseItem)
        {
            mirrorTime += Time.deltaTime * 2;
            mirrorTime = Mathf.Clamp(mirrorTime, 0.0f, 5.0f);
        }
        //Debug.Log(mirrorTime);
    }
    void Summon(ItemClass item)
    {
        //Debug.Log("player wanted to use a " + item);
        ItemClass new_item = Instantiate(mirror, itempos.position, Quaternion.identity);
        new_item.itempos = itempos;
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
        yield return new WaitForSeconds(2.0f);
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