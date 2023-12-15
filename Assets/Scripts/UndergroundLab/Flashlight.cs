using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private KeyCode flashKey = KeyCode.F;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private TextMeshProUGUI batteryIndicator;

    private bool isOn;
    private float battery = 1f;
    private float batteryUse = 0.0001f;

    private void Start()
    {
        ToggleFlashLight();
    }

    void Update()
    {
        if (Input.GetKeyDown(flashKey) && battery > 0)
        {
            ToggleFlashLight();
        }
    }

    private void FixedUpdate()
    {
        if (isOn == true && battery > 0)
        {
            battery -= batteryUse;
            batteryIndicator.text = "Battery: " + (Math.Round(battery, 2) * 100).ToString() + "%";
        }
        else if (isOn == true && battery <= 0)
        {
            ToggleFlashLight();
        }
    }

    private void ToggleFlashLight()
    {
            isOn = !isOn;
            flashLight.SetActive(isOn);
    }
}
