using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSliderHandle : MonoBehaviour
{
    public CircleSlider circleSlider;
    public HandGrabbing handR;

    private void OnTriggerEnter(Collider other)
    {
        if (handR.isPinch)
        {
            circleSlider.isDrag = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (handR.isPinch)
        {
            circleSlider.isDrag = true;
        }
    }
}
