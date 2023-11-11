using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWithMouseWheel : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10;

    public Camera zoomCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomCamera.orthographic)
        {
            zoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        } else
        {
            zoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        
    }
}
