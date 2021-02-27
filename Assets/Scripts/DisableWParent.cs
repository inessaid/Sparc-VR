using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWParent : MonoBehaviour
{
    public GameObject parent;
    private void Update()
    {
        if(parent == null)
        {
            Debug.Log("Null Parent");
        }

        if (parent.activeSelf == false)
        {
            gameObject.SetActive(false);
        }


        else
            gameObject.SetActive(true);
    }
}
