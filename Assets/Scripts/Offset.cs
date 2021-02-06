using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    Transform sObject;
    public Transform lObject;
   
    //Position
    Vector3 oldPosition, newPosition, posDiff;
    //Rotation
    Quaternion oldRotate, newRotate, rotDiff;

    void Start()
    {
        sObject = this.gameObject.transform;
        oldPosition = sObject.position;
        oldRotate = sObject.rotation;


    }

    void Update()
    {
        //Store new Position & rotation
      //  newPosition = sObject.position;
      //  newRotate = sObject.rotation;

        //Calculte difference in small object
       // posDiff = newPosition - oldPosition;
      //  rotDiff = newRotate * Quaternion.Inverse(oldRotate);
       
        //Apply difference to large object
      //  lObject.position += posDiff*4;
       // lObject.rotation = oldRotate * rotDiff;

        //Set oldPos to current position
      //  oldPosition = sObject.position;


        // new way
        lObject.transform.localRotation = sObject.transform.localRotation;
        lObject.transform.localPosition = sObject.transform.localPosition;
    }
}
