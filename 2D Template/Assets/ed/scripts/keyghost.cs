using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class keyghost : MonoBehaviour
{
    public GameObject player;
    public EnemyHealth enemy_hp;
    public GameObject ghost_summon_attack;
    public GameObject ghost_bone_attack;
    public bool attacking_player = false;
    public int ghosts_nearby = 0;

    private void Start()
    {
        player = GameObject.Find("player");
    }
    void Update()
    {
        if (enemy_hp.GetComponent<EnemyHealth>().health <= 0)
        {
            Debug.Log("spawned a key");
        }
    }
    public void StartAttacking()
    {
        if (attacking_player)
        {
            return;
        }
        attacking_player = true;
        StartCoroutine(summon_loop());
        StartCoroutine(bone_loop());
    }
    public IEnumerator summon_loop()
    {
        GameObject summon_attack = Instantiate(ghost_summon_attack, new Vector3(player.transform.position.x, player.transform.position.y, 0), player.transform.rotation);
        summon_attack.GetComponent<spawn_ghost_attack>().key_ghost = gameObject;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(summon_loop());
    }
    public IEnumerator bone_loop()
    {
        GameObject summon_attack = Instantiate(ghost_bone_attack, new Vector3(transform.position.x, transform.position.y + 2, 0), transform.rotation);
        summon_attack.GetComponent<bone_attack>().player = player;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(bone_loop());
    }
}
