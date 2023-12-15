using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Breath : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI oxygenIndicator;

    public float oxygenLevel = 1f;
    private float breathRate = 0.001f;

    private void Start()
    {
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
        }
    }

    private void UpdateDisplay()
    {
        oxygenIndicator.text = "O2: " + (Math.Round(oxygenLevel, 2) * 100).ToString() + "%";
    }

    public void ReplenishOxygen(float oxygen)
    {
        Debug.Log("Replenished: " + oxygen);
        oxygenLevel = Mathf.Clamp(oxygenLevel + oxygen, 0f, 1f);
        UpdateDisplay();
    }
}
