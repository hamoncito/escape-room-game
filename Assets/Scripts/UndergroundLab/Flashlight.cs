using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private KeyCode flashKey = KeyCode.F;
    [SerializeField] private TextMeshProUGUI batteryIndicator;
    [SerializeField] [Range(0.001f, 0.01f)] private float batteryUse = 0.01f;
    [SerializeField] [Range(1, 10)] private float range = 5f;
    [SerializeField][Range(1, 1.5f)] private float intensity = 1.5f;
    [SerializeField] [Range(1,179)] private int angle = 60;


    private bool isOn;
    private float battery = 100f;
    private Light flashlight;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetupLight();
    }

    private void SetupLight()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = isOn;
        flashlight.range = range;
        flashlight.intensity = intensity;
        flashlight.spotAngle = angle;
        batteryIndicator.text = "Battery: " + (Math.Round(battery).ToString()) + "%";
    }

    void Update()
    {
        if (Input.GetKeyDown(flashKey) && battery > 0)
        {
            audioSource.Play();
            ToggleFlashLight();
        }
    }

    private void FixedUpdate()
    {
        HandleBattery();
    }

    private void HandleBattery()
    {
        if (isOn == true && battery > 0)
        {
            battery -= batteryUse;
            batteryIndicator.text = "Battery: " + (Math.Round(battery).ToString()) + "%";
        }
        else if (isOn == true && battery <= 0)
        {
            ToggleFlashLight();
        }
    }

    private void ToggleFlashLight()
    {
            isOn = !isOn;
            flashlight.enabled = isOn;
    }
}
