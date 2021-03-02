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

        if (parent.activeSelf == true)
        {
            gameObject.SetActive(true);
        }


        else
            gameObject.SetActive(false);
    }
}
