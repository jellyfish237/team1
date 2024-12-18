using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_instances : MonoBehaviour
{
    // Start is called before the first frame update
    public void DeleteEverything()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}