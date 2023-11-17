using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    public GameObject inspectableObject;

    private void Awake()
    {
        TurnOffInspectionObject();
    }
    public void TurnOnInspectionObject()
    {
        inspectableObject.SetActive(true);
    }

    public void TurnOffInspectionObject()
    {
        inspectableObject.SetActive(false);
    }
}
