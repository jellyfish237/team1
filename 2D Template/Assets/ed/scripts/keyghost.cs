using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class keyghost : MonoBehaviour
{
    public GameObject player;
    public EnemyHealth enemy_hp;
    public GameObject ghost_summon_attack;
    public bool attacking_player = false;

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
    public void StartSummonCooldown()
    {
        attacking_player = true;
        StartCoroutine(summon_loop());
    }
    public IEnumerator summon_loop()
    {
        Debug.Log("spawned more ghosts");
        GameObject summon_attack = Instantiate(ghost_summon_attack, new Vector3(player.transform.position.x, player.transform.position.y, 0), player.transform.rotation);
        yield return new WaitForSeconds(20.0f);
        StartCoroutine(summon_loop());
    }
}
