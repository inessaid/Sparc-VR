using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    bool isOn;
    public GameObject Canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
            Canvas.SetActive(true);
        else
            Canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        isOn = !isOn;

    }
  
}
