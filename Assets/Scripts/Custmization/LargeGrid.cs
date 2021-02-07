using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeGrid : MonoBehaviour
{
  //  public GameObject indicator;
    public float[,] Grid;
    public int vertical, horizontal;
    private int colums, rows;
    private GameObject prevObj;

    private void Start()
    {
        colums = horizontal * 2;
        rows = vertical * 2;
        Grid = new float[colums, rows];
        for (int i = 0; i < colums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Grid[i, j] = Random.Range(0.0f, 1.0f);
                SpawnSlot(i, j);
            }
        }

        
        gameObject.transform.position = new Vector3(-2.085f, -0.553f, 1.176f);
    }

    public void SpawnSlot(int x, int y)
    {
        
        GameObject slot = new GameObject("L" + x.ToString() + "," + y.ToString());
        slot.transform.position = new Vector3(x - (horizontal - 2.5f), 0, y - (vertical - 2.3f));
        slot.transform.SetParent(gameObject.transform);
    }

    public GameObject Spawnfile(string name, GameObject obj)
    {

        var target = GameObject.Find(name);

        /*
        if (prevObj)
        {
            Destroy(prevObj);
        }
        */

        prevObj = Instantiate(obj, target.transform.position, Quaternion.identity);
        prevObj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);       
        prevObj.transform.SetParent(target.transform);
        Debug.Log("Spawn Large Obj");


        return prevObj;
    }

    
    public GameObject GetCurrentObject()
    {
        return prevObj;
    }

    public Transform GetPosition(string name)
    {
        Transform position = GameObject.Find(name).transform;

        return position;
    }

}
