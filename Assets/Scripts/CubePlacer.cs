using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
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
        gameObject.transform.position = other.transform.position;
        Debug.Log("Pos:" + other.name);
        LargeGrid.Spawnfile("L" + other.name, objPrefab);
    }

    private void OnTriggerStay(Collider other)
    {
        gameObject.transform.position = other.transform.position;
    }


}
