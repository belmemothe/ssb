﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.SceneManagement;

public class Drawingcontroller : MonoBehaviour {

    private int success;
    public static float successProgression = 0;
    public static int dotProgression = 0;
    private int dotProgressionPlus = 0;
    private int dotProgressionMoins = 0;
    private Vector3 currentDotPos = new Vector3(0,0,0);
    private Vector3 nextDotPos = new Vector3(0, 0, 0);
    public static string currentDotName;



    AudioSource audioSource;

    [Header("Sounds")]
    public float pitchRateControl = 1f;    
    public AudioClip Ding;
    public AudioClip Buzz;
    public AudioClip Validate;
    public AudioClip NiceOne;
    public AudioClip Boo;

    [Header("Sprites")]
    public GameObject finishedSprite;
    public GameObject defeatSprite;
    public GameObject ghost;

    [Header("Options")]
    public float timeLeft = 60f;
    public static float globalTimeLeft = 0f;
    public static float originalTimeLeft;
    public float difficulty = 0.1f;
    public float ghostSpeed = 1f;


    //ghost
    private float ghostStartTime;
    private float ghostJourneyLength;
    private float ghostDistCovered;
    private float ghostFracJourney;

    
    private int patternAdvancement = 0; // which pattern is it during phase x
    private bool patternFinished = true; // is the pattern finished and needs a small pause
    private float freezeTime = 0f; // how long has the pause been already
    public float waitTime = 0.5f; // how long does the pause have to be
    private bool transitionDone = false; // has the Transition() function been procced
    private bool phaseEnd = false; // did the player finish phase x
    private bool defeat = false; // did the player lose

    private bool failSafe = false; 
       
    public static bool cinematicFinished = false; // is the game currently inside a cinematic ?

    [Header("Level")]
    public GameObject[] patternsPhase1;
    public GameObject[] patternsPhase2;
    public GameObject[] patternsPhase3;
    private GameObject ghostObject;

    public static int patternsPhase = 0;
    private GameObject[] whichPattern;

    [Header("Entractes")]
    public GameObject Entracte1;
    public GameObject Entracte2;


    // Use this for initialization
    void Start() {

        audioSource = GetComponent<AudioSource>();
        originalTimeLeft = timeLeft;

      

    }


    private void Update()
    {
        // Phase Checker

        if ( patternsPhase == 0)
        {
            whichPattern = patternsPhase1;
        }

        if ( patternsPhase == 1)
        {
            whichPattern = patternsPhase2;
        }

        if (patternsPhase == 2)
        {
            whichPattern = patternsPhase3;
        }

        // Pattern Spawner
        
        if (cinematicFinished && patternFinished && (patternAdvancement < whichPattern.Length))
        {
            
            Instantiate(whichPattern[patternAdvancement], new Vector3(0, 0, 0), Quaternion.identity);
            ghostObject = Instantiate(ghost, new Vector3(0, 0, 0), Quaternion.identity);
            patternFinished = false;
            transitionDone = false;
            failSafe = true;

            //Reset Variables

            dotProgression = 0;
            timeLeft = originalTimeLeft;
            ghostStartTime = Time.time;

        }

        if (patternAdvancement >= whichPattern.Length && !phaseEnd)
        {
            phaseEnd = true;
            failSafe = false;
            cinematicFinished = false;
            GameObject tempCircle = Instantiate(finishedSprite, new Vector3(0, 0, 0), Quaternion.identity);
            audioSource.pitch = 1.0f;
            audioSource.PlayOneShot(NiceOne, 1.0f);

            for (float i = 0; i < waitTime; i += Time.deltaTime)
            {

            }

            Destroy(tempCircle);
            Instantiate(Entracte1);
            

        }

        if (defeat && !phaseEnd)
        {
            phaseEnd = true;
            GameObject.Find(whichPattern[patternAdvancement].name + "(Clone)").GetComponent<PatternHandler>().DotDestroy();
            Instantiate(defeatSprite, new Vector3(0, 0, 0), Quaternion.identity);
            audioSource.pitch = 1.0f;
            audioSource.PlayOneShot(Boo, 1.0f);
            Destroy(ghostObject);
        }
    }

    private void LateUpdate()
    {
        if (failSafe)
        {
            if (!phaseEnd && !defeat)
            {
                //////////////////// Dot Observer ////////////////////

                success = PatternHandler.dotsLength;
                dotProgressionPlus = dotProgression + 1;
                dotProgressionMoins = dotProgression - 1;
                currentDotName = "Dot" + dotProgression + "";

                if (GameObject.Find("Dot" + dotProgression + "") != null && GameObject.Find("Dot" + dotProgressionPlus + "") != null)
                {
                    if (dotProgression == 0 || dotProgression > 2)
                    {
                        currentDotPos = GameObject.Find("Dot" + dotProgression + "").transform.position;
                        nextDotPos = GameObject.Find("Dot" + dotProgressionPlus + "").transform.position;
                    }
                    if (dotProgression > 0 && dotProgression < 3)
                    {
                        currentDotPos = GameObject.Find("Dot" + dotProgressionMoins + "").transform.position;
                        nextDotPos = GameObject.Find("Dot" + dotProgression + "").transform.position;
                    }
                }
                else
                {
                    currentDotPos = new Vector3(2, 2, 2);
                    nextDotPos = new Vector3(0, 0, 0);
                }

                //////////////////////// Ghost ////////////////////////

                ghostJourneyLength = Vector2.Distance(currentDotPos, nextDotPos);
                ghostDistCovered = (Time.time - ghostStartTime) * ghostSpeed;
                ghostFracJourney = ghostDistCovered / ghostJourneyLength;

                //GameObject.Find("Ghost(Clone)").transform.position = Vector2.Lerp(currentDotPos, nextDotPos, ghostFracJourney);
                if (ghostObject != null)
                {
                    ghostObject.transform.position = Vector2.Lerp(currentDotPos, nextDotPos, ghostFracJourney);

                    if (ghostObject.transform.position == nextDotPos)
                    {
                        ghostStartTime = Time.time;
                    }
                }
                




                //////////////////// Trigger Handler ////////////////////

                if (successProgression == 1)
                {
                    audioSource.pitch = 1 + dotProgression / pitchRateControl;
                    dotProgression++;
                    Linedrawing.lineLength = 0;
                    successProgression = 0;

                    if (dotProgression < success)
                    {
                        audioSource.PlayOneShot(Ding, 1f);
                    }

                    timeLeft += originalTimeLeft * difficulty;
                }

                if (dotProgression == success && dotProgression > 0)
                {
                    
                    audioSource.pitch = 1f;
                    audioSource.PlayOneShot(Validate, 1f);
                    dotProgression++;

                    GameObject.Find(whichPattern[patternAdvancement].name + "(Clone)").GetComponent<PatternHandler>().DotDestroy();
                    GameObject.Find(whichPattern[patternAdvancement].name + "(Clone)").GetComponent<SpriteRenderer>().enabled = true;

                    
                    patternFinished = true;
                    cinematicFinished = false;


                }

                //////////////////// Ink Handler ////////////////////

                if (Linedrawing.lineLength > (currentDotPos - nextDotPos).magnitude * 2)
                {
                    audioSource.pitch = 1f;
                    audioSource.PlayOneShot(Buzz, 1f);
                    Linedrawing.lineLength = 0;

                    timeLeft -= originalTimeLeft * difficulty;
                    dotProgression = 0;
                    Destroy(GameObject.Find("Line(Clone)"));
                }

                //////////////////// Timer ////////////////////

                globalTimeLeft = timeLeft;

                if (!patternFinished)
                {

                    timeLeft -= Time.deltaTime;
                }

                if (timeLeft > originalTimeLeft)
                {

                    timeLeft = originalTimeLeft;
                }

                if (timeLeft < 0)
                {
                    defeat = true;
                    timeLeft = 0;

                }

                if (patternFinished)
                {
                    freezeTime += Time.deltaTime;

                    if (freezeTime > waitTime && !transitionDone)
                    {
                        transitionDone = true;
                        freezeTime = 0f;
                        Transition();
                    }
                }



                //////////////////// Reset ////////////////////

                if (Input.GetKeyDown(KeyCode.A))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    Destroy(GameObject.Find("Line(Clone)"));
                    dotProgression = 0;
                }
            }
        }        
    }

    ///////////// Pattern Transition //////////
    public void Transition()
    {
        
        Destroy(GameObject.Find(whichPattern[patternAdvancement].name + "(Clone)"));
        Destroy(ghostObject);
        cinematicFinished = true;
        patternAdvancement++;
    }

}