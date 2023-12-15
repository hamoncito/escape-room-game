using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AirStation : MonoBehaviour
{
    [SerializeField] private TextMeshPro oxygenIndicator;

    private float oxygenLevel = 1f;
    private float exchangeRate = 3f;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Breath playerBreath))
        {
            if (oxygenLevel >= 0)
            {
                playerBreath.ReplenishOxygen(0.001f * exchangeRate);
                oxygenLevel -= 0.001f;
                oxygenIndicator.text = (Math.Round(oxygenLevel, 2) * 100).ToString() + "%";
            }
        }
    }
}
