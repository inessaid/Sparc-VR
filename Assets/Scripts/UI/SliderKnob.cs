using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderKnob : MonoBehaviour
{
    public Slider timeSlider;
    public HandGrabbing handR;
    GameObject indexFinger;
    bool isMove;
    float prevX;
    float maxX, minX, length;

    private void Start()
    {
        maxX = 74;
        minX = -70;
        length = maxX - minX;
    }

    void Update()
    {
        prevX = handR.transform.position.x;
        //Convert Value to 0-10
        float ratio = (gameObject.transform.localPosition.x - minX) / length * 10;
        Debug.Log("Ratio: " + ratio);

        timeSlider.value = ratio;

        if (isMove)
            MoveThis();
        


        //Clamp
        if (gameObject.transform.localPosition.x > maxX)
            gameObject.transform.localPosition = new Vector3(maxX, gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.localPosition.x < minX)
            gameObject.transform.localPosition = new Vector3(minX, gameObject.transform.position.y, gameObject.transform.position.z);
       
        //If not not pinch, let go
        if (handR.isPinch == false)
            isMove = false;
    }

    private void OnTriggerEnter(Collider other)
    {
       if( handR.isPinch == true)
        {
            indexFinger = other.gameObject;
            isMove = true;
            
        }
    }

    

    void MoveThis()
    {
        float deltaX = indexFinger.transform.position.x - prevX;
        this.gameObject.transform.position = new Vector3(indexFinger.transform.position.x + deltaX, gameObject.transform.position.y, gameObject.transform.position.z);

        



    }
}
