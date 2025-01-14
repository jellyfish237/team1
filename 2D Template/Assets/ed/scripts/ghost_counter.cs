using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_counter : MonoBehaviour
{
    private List<Collider2D> list = new List<Collider2D>();
    void OnTriggerEnter2D(Collider2D ghost)
    {
        Debug.Log("CollidedWithGhost");
        if (!list.Contains(ghost))
        {
            if (ghost.gameObject.CompareTag("ghost"))
            {
                list.Add(ghost);
                GetComponentInParent<keyghost>().ghosts_nearby += 1;
            }
        }
    }
    void OnTriggerExit2D(Collider2D ghost)
    {
        if (list.Contains(ghost))
        {
            if (ghost.gameObject.CompareTag("ghost"))
            {
                list.Remove(ghost);
                GetComponentInParent<keyghost>().ghosts_nearby -= 1;
            }
        }
    }
}