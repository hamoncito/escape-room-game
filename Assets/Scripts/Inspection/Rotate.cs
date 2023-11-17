using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 lastPos, currPos;
    public float rotationSpeed = -0.2f;

    
    void Start()
    {
        lastPos = Input.mousePosition;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            currPos = Input.mousePosition;
            Vector3 offset = currPos - lastPos;

            // Rotate around Y axis
            transform.Rotate(Vector3.up, offset.x * rotationSpeed);

            // Rotate around X axis
            transform.Rotate(Vector3.right, offset.y * rotationSpeed);

            // Rotate around Z axis
            transform.Rotate(Vector3.forward, offset.z * rotationSpeed);

            lastPos = currPos;
        }
        lastPos = Input.mousePosition;
    }
}
