using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_shake : MonoBehaviour
{
    public IEnumerator camera_shake()
    {
        Vector3 orginalPos = transform.localPosition;
        float time = 0.0f;

        while (time < 0.5f)
        {
            float x = Random.Range(-0.5f, 0.5f);
            float y = Random.Range(-0.5f, 0.5f);

            transform.localPosition = new Vector3(x, y, -13);

            time += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = orginalPos;
    }
}
