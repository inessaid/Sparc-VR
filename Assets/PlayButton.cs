using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public controlanimation controlanimation;
    public GameObject btnPause;
    public GameObject btnPlay;
    bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        btnPause.SetActive(false);
        btnPlay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPlaying)
        {
            controlanimation.Stop();
            btnPause.SetActive(true);
            btnPlay.SetActive(false);
        }

        if (!isPlaying)
        {
            controlanimation.play();
            btnPause.SetActive(false);
            btnPlay.SetActive(true);
        }

        isPlaying = !isPlaying;
    }
}
