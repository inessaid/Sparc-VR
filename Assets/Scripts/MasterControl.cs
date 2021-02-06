using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControl : MonoBehaviour
{
    bool isHitting;
    GameObject hand;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            isHitting = true;
            hand = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isHitting = false;
    }
    public void startFollow()
    {
        if (isHitting)
        {
            gameObject.transform.parent = hand.transform;
        }
    }
}
