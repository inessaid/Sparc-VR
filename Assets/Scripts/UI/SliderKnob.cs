using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SliderKnob : MonoBehaviour
{
    public Slider timeSlider;
    public TMP_Text frameNumTxt;
    public HandGrabbing handR;
    public controlanimation controlanimation;

    GameObject indexFinger;
    bool isMove;
    float prevX;
    float maxX, minX, length;

    private void Start()
    {
        maxX = 175;
        minX = -175;
        length = maxX - minX;
    }

    void Update()
    {
        prevX = handR.transform.position.x;
        //Convert Value to 0-10
        float ratio = (gameObject.transform.localPosition.x - minX) / length * 24;
        

        timeSlider.value = ratio;
        frameNumTxt.text = timeSlider.value.ToString();

        if (isMove)
            MoveThis();
        


        //Clamp
        if (gameObject.transform.localPosition.x > maxX)
            gameObject.transform.localPosition = new Vector3(maxX, gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.localPosition.x < minX)
            gameObject.transform.localPosition = new Vector3(minX, gameObject.transform.position.y, gameObject.transform.position.z);
       
        //If not not pinch, let go
        if (handR.isPinch == false && isMove == true)
        {
            isMove = false;
            controlanimation.setkeySlider();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if( handR.isPinch == true)
        {
            controlanimation.setkeySlider();
            indexFinger = other.gameObject;
            isMove = true;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (handR.isPinch == true)
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
