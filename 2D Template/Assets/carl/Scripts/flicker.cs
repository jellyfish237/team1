using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public Light leLight;
    public float maxInterval = 2;
    public float maxBurst = 1f;
    public float maxFlicker = 0.2f;

    float defaultInten;
    bool Flicker;
    float timer;
    float interval;
    // Start is called before the first frame update
    void Start()
    {
        defaultInten = leLight.intensity;
        interval = Random.Range(0,maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Flicker)
        {
            timer += Time.deltaTime;
        }

        if (timer > interval)
        {
            interval = Random.Range(0, maxInterval);
            timer = 0;
            StartCoroutine(FlickerLight(Random.Range(0,maxBurst)));
        }
    }

    IEnumerator FlickerLight(float duration)
    {
        Flicker = true;
        float totalTime = 0;
        float flickerTimer = 0;
        float flickerInterval = Random.Range(0, maxFlicker);

        while (totalTime < duration)
        {
            totalTime += Time.deltaTime;
            flickerTimer += Time.deltaTime;

            if (flickerTimer > flickerInterval)
            {
                leLight.intensity = Random.Range(0.5f, defaultInten);
                flickerInterval = Random.Range(0, maxFlicker);
                flickerTimer = 0;
            }
            yield return null;
        }

        leLight.intensity = defaultInten;
        Flicker = false;
    }
}