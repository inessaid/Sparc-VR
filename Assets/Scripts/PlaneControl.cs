using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    Transform sObject;
    public Transform lObject;

    public HandGrabbing handGrabbingL, handGrabbingR;
    public GameObject handL, handR;
    bool isGrabbed, isColliding;
    float prevX, prevY;

    void Start()
    {
        sObject = this.gameObject.transform;

    }

    void Update()
    {
        if (handGrabbingL.isPinch == false || handGrabbingR.isPinch == false) 
            isGrabbed = false;
        
        if (isGrabbed)
        {
            RotateThis();
            //TranslateThis();
        }

        prevX = handR.transform.localPosition.x;


        //Update large grid rotation;
        lObject.transform.localRotation = sObject.transform.localRotation;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (handGrabbingL.isPinch == true || handGrabbingR.isPinch == true )
        {
            isGrabbed = true;
            isColliding = true;

        }

        else
            Debug.Log("Not Pinching");
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }

    void RotateThis()
    {

        float delta = handR.transform.localPosition.x - prevX;
        sObject.transform.Rotate(0, -delta *360,  0);
        
    }


    void TranslateThis()
    {

    }
}
