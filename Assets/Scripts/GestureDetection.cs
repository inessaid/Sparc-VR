using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecongnized;
}

public class GestureDetection : MonoBehaviour
{
    public float threshhold = 0.1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones;
    public bool debugMode;

    private Gesture previousGesture;


    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);

        previousGesture = new Gesture();
    }

    void Update()
    {
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Save It");
            Save();
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());
        if(hasRecognized && !currentGesture.Equals(previousGesture))
        {
            previousGesture = currentGesture;
            currentGesture.onRecongnized.Invoke();
        }
    }

    void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach(var bone in fingerBones)
        {
            //finger position relative to root
            Debug.Log(skeleton.transform.InverseTransformPoint(bone.Transform.position));
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        g.fingerDatas = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentgesture = new Gesture();
        float currentMin = Mathf.Infinity;
        foreach(var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for(int i = 0; i< fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
                if (distance > threshhold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }

            if(!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentgesture = gesture;
            }
        }
        return currentgesture;
    }
}
