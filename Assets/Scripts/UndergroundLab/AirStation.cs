using System;
using TMPro;
using UnityEngine;

public class AirStation : MonoBehaviour
{
    [SerializeField] private TextMeshPro oxygenIndicator;
    [SerializeField] private KeyCode rechargeKey = KeyCode.R;

    private float oxygenLevel = 100f;
    private float exchangeRate = 2f;

    private void OnTriggerStay(Collider other)
    {
        Breath playerBreath = other.transform.parent.GetComponentInChildren<Breath>(false);

        if (playerBreath != null)
        {
            if (oxygenLevel >= 0 && Input.GetKey(rechargeKey))
            {
                playerBreath.ReplenishOxygen(0.001f * exchangeRate);
                oxygenLevel -= 0.001f;
                oxygenIndicator.text = Math.Round(oxygenLevel).ToString() + "%";
            }
        }
    }
}
