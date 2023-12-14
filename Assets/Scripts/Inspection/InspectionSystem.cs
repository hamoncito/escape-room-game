using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InspectionSystem : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private float pickupRange;

    public Button exitButton;
    public GameObject inspectTip;
    public GameObject inspection;
    public InspectableObject inspectableObject;

    private void Awake()
    {
        exitButton.onClick.AddListener(TurnCursorOff);
        inspection.SetActive(false);
        inspectTip.SetActive(false);
    }
    private void Update()
    {
        inspectTip.SetActive(false);
        RaycastHit hitInfo;
        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // Inspected
        if (GetComponent<Collider>().Raycast(cameraRay, out hitInfo, pickupRange))
        {
            inspectTip.SetActive(true);
            
            if (Input.GetKey(KeyCode.E))
            {
                playerCamera.GetComponent<PlayerCamera>().enabled = false;
                cameraHolder.GetComponent<MoveCamera>().enabled = false;
                player.GetComponent<PhysicsPickup>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                inspection.SetActive(true);
                inspectableObject.TurnOnInspectionObject();
                Debug.Log("Inspected item - InspectionSystem");
            }
        }

    }

    public void TurnCursorOff()
    {
        Cursor.visible = false;
    }


}
