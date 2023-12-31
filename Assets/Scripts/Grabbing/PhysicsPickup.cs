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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currObj)
            {
                currObj.useGravity = true;

                // Release object's grabbed status (re-enables player collisions)
                try
                {
                    PickupStatus pickupStatus = currObj.GetComponent<PickupStatus>();
                    pickupStatus.currentlyGrabbed = false;
                }
                catch
                {
                    Debug.Log(currObj + " has no PickupStatus script attached. :/");
                }
                currObj = null;

                return;
            }

            RaycastHit hitInfo;
            Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            // Grabbed
            if (Physics.Raycast(cameraRay, out hitInfo, pickupRange, isGrabbable))
            {
                currObj = hitInfo.rigidbody;
                currObj.useGravity = false;
                Debug.Log("grabbed");

                // Change object's status to "grabbed" (each object might have different settings for when grabbed, e.g., slowing down player more, smoothing)
                try
                {
                    PickupStatus pickupStatus = currObj.GetComponent<PickupStatus>();
                    pickupStatus.currentlyGrabbed = true;
                }
                catch
                {
                    Debug.Log(currObj + " has no PickupStatus script attached. :/");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (currObj)
        {
            Vector3 directionToPoint = pickupTarget.position - currObj.position;
            float distanceToPoint = directionToPoint.magnitude;

            if (currObj.GetComponent<PickupStatus>() != null)
            {
                currObj.velocity = directionToPoint * currObj.GetComponent<PickupStatus>().grabbedAirSpeed * distanceToPoint;
            }
            else
            {
                currObj.velocity = directionToPoint * 12f * distanceToPoint;
            }
        }
    }
}