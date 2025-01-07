using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    //public GameObject enemy;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    public void Start()
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
