using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStatus : MonoBehaviour
{
    public bool currentlyGrabbed = false;

    // Physics layer on which the object starts
    private int neutralLayer = 7;

    // Physics layer when the object has been picked up
    private int grabbedLayer = 12;

    public float grabbedAirSpeed = 12f;
    public float outlineThick = 4f;

    // Highlighting
    private GameObject player;

    private Outline outline;

    //Assign references
    private void Awake()
    {
        player = GameObject.Find("Player");
        try
        {
            outline = GetComponent<Outline>();
        }
        catch { }
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Start off normally
        gameObject.layer = neutralLayer;
    }

    // Update is called once per frame
    private void Update()
    {
        //Change layers when grabbed
        gameObject.layer = currentlyGrabbed ? grabbedLayer : neutralLayer;

        //Change outline
        // Nie wszystko ma outline wiêc jest otoczone try-catchem
        try
        {
            if ((!currentlyGrabbed) && player.GetComponent<LookAtDetector>().detectedObject == gameObject)
            {
                outline.OutlineWidth = outlineThick;
            }
            else
            {
                outline.OutlineWidth = 0;
            }
        }
        catch { }
    }
}