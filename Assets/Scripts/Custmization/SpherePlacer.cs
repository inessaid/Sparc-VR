using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlacer : MonoBehaviour
{
    private Grid grid;
    private Vector3 mOffset;
    private float mZCoord;

    public LargeGrid LargeGrid;
    public GameObject objPrefab;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
      
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.transform.childCount > 0)
            gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
        */

        gameObject.transform.position = other.transform.position;
        //gameObject.transform.SetParent(other.transform);

        Debug.Log("Pos:" + other.name);
        LargeGrid.Spawnfile("L" + other.name, objPrefab);
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject lObj = LargeGrid.GetCurrentObject();
        lObj.transform.localRotation= gameObject.transform.localRotation;
        gameObject.transform.position = other.transform.position;
    }


}
