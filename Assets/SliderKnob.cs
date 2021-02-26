using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderKnob : MonoBehaviour
{
    GameObject handR;
    bool isMove;
    float prevX;

    void Update()
    {
        Debug.Log(gameObject.transform.localPosition.x);
        prevX = handR.transform.position.x;
        if (isMove)
            MoveThis();
    }

    private void OnTriggerEnter(Collider other)
    {
       if( other.gameObject.name == "Hand_IndexTip")
        {
            handR = other.gameObject;
               isMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isMove = false;
    }

    void MoveThis()
    {
        float deltaX = handR.transform.position.x - prevX;
        this.gameObject.transform.position = new Vector3(handR.transform.position.x + deltaX, gameObject.transform.position.y, gameObject.transform.position.z);

     
    }
}
