using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoObject : MonoBehaviour
{
    //Prefabs
    public GameObject[] Prefabs;


    public int Index;
    int overlap;

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOverlapping)
        {
            Debug.Log("Clone");
            GameObject newItem = Instantiate(Prefabs[Index], gameObject.transform.position, Quaternion.identity);
            newItem.transform.SetParent(gameObject.transform, false);

        }
    }

    public bool isOverlapping
    {
        get
        {
            return overlap > 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        overlap++;
    }

    private void OnTriggerExit(Collider other)
    {
        overlap--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(this.gameObject, transform.position, Quaternion.identity);
    }
}
