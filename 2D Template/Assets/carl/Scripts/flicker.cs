using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flicker : MonoBehaviour
{
    public float maxInterval = 2;
    public float maxBurst = 1f;
    public float maxFlicker = 0.2f;

    float defaultInten;
    float defaultRadius;
    bool Flicker;
    float timer;
    float interval;
    public Light2D leLight;
    // Start is called before the first frame update
    void Start()
    {
        defaultInten = GetComponent<Light2D>().intensity;
        defaultRadius = GetComponent<Light2D>().pointLightOuterRadius;
        var myName = this.name;
        if (myName != "player" && myName != "N_teleport" && myName != "W_teleport" && myName != "S_teleport" && myName != "E_teleport" && myName != "UP" && myName != "Mirror" && myName != "StrongMirror" && myName != "Banana")
        {
            int rng = Random.Range(0,2);
            if (rng == 1)
            {
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        if (!Flicker)
        {
            timer += Time.deltaTime;
        }

        if (timer > interval)
        {
            interval = Random.Range(1, maxInterval);
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
                leLight.pointLightOuterRadius = Mathf.Lerp(GetComponent<Light2D>().pointLightOuterRadius, Random.Range(defaultRadius * 0.8f, defaultRadius * 1.2f), Random.Range(0.5f, 0.8f));
                leLight.intensity = Mathf.Lerp(GetComponent<Light2D>().intensity, Random.Range(defaultInten * 0.8f, defaultInten * 1.2f), Random.Range(0.5f, 0.8f));
                flickerInterval = Random.Range(0, maxFlicker);
            }
            yield return null;
        }
        leLight.pointLightOuterRadius = Mathf.Lerp(GetComponent<Light2D>().pointLightOuterRadius, Random.Range(defaultRadius * 0.8f, defaultRadius * 1.2f), Random.Range(0.5f, 0.8f));
        leLight.intensity = Mathf.Lerp(GetComponent<Light2D>().intensity, Random.Range(defaultInten * 0.8f, defaultInten * 1.2f), Random.Range(0.5f, 0.8f));
        Flicker = false;
    }
}
