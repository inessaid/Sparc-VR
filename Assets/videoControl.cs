using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class videoControl : MonoBehaviour
{
    VideoPlayer video;
    public Slider slider;

    private void Start()
    {
        video = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        video.frame = (long)slider.value;
        Debug.Log("Frame: " + video.frame);
    }
}
