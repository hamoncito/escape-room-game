using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    public GameObject inspectableObject;
    public GameObject[] inspectableObjects;
    
    public void TurnOnInspectionObject()
    {
        inspectableObject.SetActive(true);
    }

    public void TurnOffInspectionObject()
    {
        inspectableObject.SetActive(false);
    }

    public void TurnOnInspection()
    {
        for (int i = 0; i < inspectableObjects.Length; i++)
        {
            inspectableObjects[i].SetActive(true); 
        }
    }

    public void TurnOffInspection()
    {
        for (int i = 0; i < inspectableObjects.Length; i++)
        {
            inspectableObjects[i].SetActive(false);
        }

    }
}
