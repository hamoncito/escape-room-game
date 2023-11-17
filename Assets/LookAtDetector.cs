using UnityEngine;

public class LookAtDetector : MonoBehaviour
{
    [Header("Currently looking at:")]
    public GameObject detectedObject; // The detected object (public for easy access)

    [Space]
    public LayerMask detectionLayer; // The layer to filter detection

    public float maxDetectionDistance = 10f; // Maximum distance for detection
    public Camera mainCam;

    private void Update()
    {
        // Get the center of screen
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // Raycast from the center of the screen
        Ray ray = mainCam.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        // Do the raycast
        if (Physics.Raycast(ray, out hit, maxDetectionDistance, detectionLayer))
        {
            // Check if the detected object has changed
            if (hit.collider.gameObject != detectedObject)
            {
                // Update the detected object
                detectedObject = hit.collider.gameObject;

                // Do something with the detected object, for example, print its name
                //Debug.Log("Detected Object: " + detectedObject.name);
            }
        }
        else
        {
            // Reset the detected object if nothing is hit
            detectedObject = null;
        }
    }
}