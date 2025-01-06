using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_shake : MonoBehaviour
{
    public void StartCoroutine1()
    {
        StartCoroutine(shake());
    }
    public IEnumerator shake()
    {
        Vector3 orginalPos = transform.localPosition;
        float time = 0.0f;

        while (time < 0.5f)
        {
            float x = Random.Range(-2f, 2f);
            float y = Random.Range(-2f, 2f);
            float z = Random.Range(-12f, -14f);
            transform.localPosition = new Vector3(x, y, z);

            time += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = orginalPos;
    }
}
