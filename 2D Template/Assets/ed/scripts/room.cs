using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class room:MonoBehaviour
{
    public static Dictionary<int, room> Indicestorooms = new();

    public int given_index;
    public GameObject ghost;
    public int rng;

    // Start is called before the first frame update
    void Start()
    {
        rng = Random.Range(0, 2);
        Debug.Log(rng);
        if (rng == 0)
        {
            GameObject new_ghost = Instantiate(ghost, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
