using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlanimation : MonoBehaviour
{
    // Animate the position and color of the GameObject
    public Animation anim;
    public AnimationCurve curve,curvey,curvez;
    public Keyframe[] keys;
    public Keyframe[] keysy;
    public Keyframe[] keysz;
    public AnimationClip clip;
    public GameObject arm;
    float positionx, positiony, positionz;
    public void Start()
    {

        // create a new AnimationClip
        clip = new AnimationClip();
        clip.legacy = true;

        // create a curve to move the GameObject and assign to the clip
       
       keys = new Keyframe[4]; keysy = new Keyframe[4]; keysz = new Keyframe[4];


    }

  

    public void setkey0()
    {
       
        positionx = arm.transform.localPosition.x;
        Debug.LogError(positionx);
        keys[0] = new Keyframe(0.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[0] = new Keyframe(0.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[0] = new Keyframe(0.0f, positionz);
        Debug.Log("KeySet1");
    }
    public void setkey1()
    {
       
        positionx = arm.transform.localPosition.x;
        keys[1] = new Keyframe(1.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[1] = new Keyframe(1.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[1] = new Keyframe(1.0f, positionz);
    }
    public void setkey2()
    {
       
        positionx = arm.transform.localPosition.x;
        keys[2] = new Keyframe(2.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[2] = new Keyframe(2.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[2] = new Keyframe(2.0f, positionz);
    }

    public void setkey3()
    {

        positionx = arm.transform.localPosition.x;
        keys[3] = new Keyframe(3.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[3] = new Keyframe(3.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[3] = new Keyframe(3.0f, positionz);
    }
    public void play()
    {
       
        curve = new AnimationCurve(keys);
        curvey = new AnimationCurve(keysy);
        curvez = new AnimationCurve(keysz);
        clip.SetCurve("", typeof(Transform), "localPosition.x", curve);

        clip.SetCurve("", typeof(Transform), "localPosition.y", curvey);

        clip.SetCurve("", typeof(Transform), "localPosition.z", curvez);

        anim.AddClip(clip, clip.name);
        anim.Play(clip.name);
    }
}
