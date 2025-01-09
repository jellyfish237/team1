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

        while (time < 0.3f)
        {
            float x = Random.Range(-0.1f, 0.1f);
            float y = Random.Range(-0.1f, 0.1f);
            transform.localPosition = new Vector3(x, y, -13);

            time += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = orginalPos;
    }
}
