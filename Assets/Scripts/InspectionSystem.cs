using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InspectionSystem : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float pickupRange;

    public GameObject inspection;
    public InspectableObject inspectableObject;
    public int index;

    private void Update()
    {
        RaycastHit hitInfo;
        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // Inspected
        if (GetComponent<Collider>().Raycast(cameraRay, out hitInfo, pickupRange))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inspection.SetActive(true);
                inspectableObject.TurnOnInspection(index);
                Debug.Log("Inspected");
            }
        }

    }

}
