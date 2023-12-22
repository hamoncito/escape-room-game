using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Breath : MonoBehaviour
{
    [SerializeField] private AudioClip breathe, suffocation;
    [SerializeField] private TextMeshProUGUI oxygenIndicator;
    [SerializeField] private float breathRate = 0.1f;

    private AudioSource head;
    public float oxygenLevel = 1f;

    private void Start()
    {
        head = GetComponent<AudioSource>();
        head.clip = breathe;
        head.loop = true;
        head.Play();

        Breathe();
    }

    private void Breathe()
    {
        oxygenLevel -= breathRate;
        UpdateDisplay();

        if (oxygenLevel > 0)
        {
            Invoke(nameof(Breathe), 1f);
        }
        else
        {
            oxygenIndicator.text = "You died!";
            head.Stop();
            head.clip = suffocation;
            head.loop = false;
            head.Play();
        }
    }

    private void UpdateDisplay()
    {
        oxygenIndicator.text = "O2: " + (Math.Round(oxygenLevel, 2) * 100).ToString() + "%";
    }

    public void ReplenishOxygen(float oxygen)
    {
        oxygenLevel = Mathf.Clamp(oxygenLevel + oxygen, 0f, 1f);
        UpdateDisplay();
    }
}
