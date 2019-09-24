using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_MusicController : MonoBehaviour


{
    public static bool gameStart = false;
    public static bool gameStarted = false;

    public static bool gameStopped = false;
    public static bool gameStop = false;
    private bool end = false;
    
    private float freezetime = 0f;
    public float waitTime = 1.5f;

    AudioSource audioSource;

    public AudioClip boo;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameStart && !gameStarted)
        {
            audioSource.Play();
            gameStarted = true;
        }

        if ( gameStop && !gameStopped)
        {
            gameStopped = true;      
        }

        if (gameStopped && !end) 
        {
            freezetime += Time.deltaTime;

            audioSource.pitch += -0.005f;
            

            if (freezetime > waitTime)
            {
                end = true;
                audioSource.Stop();
                audioSource.pitch = 1f;
                audioSource.PlayOneShot(boo, 1.0f);
            }
        }

        if (Drawingcontroller.scoreBoardSpawned)
        {
            audioSource.Stop();
        }

    }
}
