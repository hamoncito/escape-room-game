using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    [SerializeField] private LayerMask isGrabbable;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform pickupTarget;
    [Space]
    [SerializeField] private float pickupRange;
    private Rigidbody currObj;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if(currObj) {
                currObj.useGravity = true;
                currObj = null;
                return;
            }

            RaycastHit hitInfo;
            Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            // Grabbed
            if (Physics.Raycast(cameraRay, out hitInfo, pickupRange, isGrabbable)) {
                currObj = hitInfo.rigidbody;
                currObj.useGravity = false;
                Debug.Log("grabbed");
            }
        }
        
    }

    void FixedUpdate()
    {
        if(currObj) {
            Vector3 directionToPoint = pickupTarget.position - currObj.position;
            float distanceToPoint = directionToPoint.magnitude;

            currObj.velocity = directionToPoint * 12f * distanceToPoint;
        }
    }
}
