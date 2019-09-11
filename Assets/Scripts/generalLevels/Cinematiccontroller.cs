using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematiccontroller : MonoBehaviour {

    AudioSource audioSource;

    public SpriteRenderer[] phase;
    private SpriteRenderer currentSprite;

    public enum TransitionType
    {
        Pop,
        SlideFromLeft,
        SlideFromRight,
        SlideFromUp,
        SlideFromDown,
        Shock,        
        PopShock

    };

    public TransitionType[] transitionType;

    public int[] phaseHop;
    public bool[] isTimer;
    public GameObject[] destroyWho;
    public GameObject[] destroyWho2;
    public GameObject[] destroyWho3;


    public AudioClip[] clip;
    public int[] audioClipPlay;
    public int[] audioClipStop;

    private Vector3 startPos;
    //private Vector3 endPos = new Vector3(0, 0, 0);

    private bool transitionFinished = false;

    private int transitionAdvancement = 0;
    private int phaseAdvancement = 0;
    private bool firstPlay = true;

    public float popSpeed = 1f;
    public Vector3 popScale = new Vector3(2, 2, 0);
    private bool going;
    private float transitionJourneyLength;
    private float transitionDistCovered;
    private float transitionPercent;
    private float transitionStartTime;

    private float freezeTime = 0f;
    public float waitTime = 0.5f;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

        Linedrawing.globalisActive = false;
        Drawingcontroller.cinematicFinished = false;


        for (int i = 0; (transitionAdvancement - phaseAdvancement) < phaseHop[phaseAdvancement]; i++)
        {
            NextPhase(transitionType[transitionAdvancement], phase[transitionAdvancement]);
            transitionAdvancement++;
        }
        phaseAdvancement = transitionAdvancement;

        if (audioClipStop[transitionAdvancement] != 0)
        {
            audioSource.Stop();
        }
        if ( audioClipPlay[transitionAdvancement] != 0)
        {
            audioSource.PlayOneShot(clip[audioClipPlay[transitionAdvancement]], 1f);
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        if ((Input.GetMouseButtonDown(0) && Drawingcontroller.cinematicFinished == false && !isTimer[transitionAdvancement]) ^ (freezeTime > waitTime))
        {
            print("mabite");
            if (transitionAdvancement >= phase.Length)
            {
                GameObject[] names = GameObject.FindGameObjectsWithTag("Cinematic");
                foreach (GameObject item in names)
                {
                    Destroy(item);
                }
                Drawingcontroller.cinematicFinished = true;
                Linedrawing.globalisActive = true;

            }

            if (transitionAdvancement < phase.Length)
            {
                if (destroyWho[transitionAdvancement] != null)
                {
                    Destroy(GameObject.Find(destroyWho[transitionAdvancement].name + "(Clone)"));
                }
                if (destroyWho2[transitionAdvancement] != null)
                {
                    Destroy(GameObject.Find(destroyWho2[transitionAdvancement].name + "(Clone)"));
                }
                if (destroyWho3[transitionAdvancement] != null)
                {
                    Destroy(GameObject.Find(destroyWho3[transitionAdvancement].name + "(Clone)"));
                }

                if (firstPlay)
                {
                    //print(transitionAdvancement);
                    firstPlay = false;
                    int tempAdv = transitionAdvancement + 1;
                    
                    if (audioClipStop[tempAdv] != 0)
                    {
                        audioSource.Stop();
                    }
                    if (audioClipPlay[tempAdv] != 0)
                    {
                        audioSource.PlayOneShot(clip[audioClipPlay[tempAdv]], 1f);
                    }

                }
                else
                {
                    if (audioClipStop[transitionAdvancement] != 0)
                    {
                        audioSource.Stop();
                    }
                    if (audioClipPlay[transitionAdvancement] != 0)
                    {
                        audioSource.PlayOneShot(clip[audioClipPlay[transitionAdvancement]], 1f);
                    }
                }
                                
                for (int i = 0; (transitionAdvancement - phaseAdvancement) < phaseHop[phaseAdvancement]; i++)
                {
                    NextPhase(transitionType[transitionAdvancement], phase[transitionAdvancement]);
                    transitionAdvancement++;
                }
                phaseAdvancement = transitionAdvancement;
                //print(transitionAdvancement);

                

                

            }
            
          

        }

        if (isTimer[transitionAdvancement-1])
        {
            freezeTime += Time.deltaTime;

        }
		
	}



    // Transition Handler

    void NextPhase(TransitionType whatTransition, SpriteRenderer whichSprite)
    {
        
        if (whatTransition == TransitionType.Pop)
        {
            currentSprite = Instantiate(whichSprite);
        }
        if (whatTransition == TransitionType.PopShock)
        {
            currentSprite = Instantiate(whichSprite);
            PopShock(whichSprite);

        }
    }

    // PopShock Transition

    void PopShock(SpriteRenderer whichSprite)
    {
        transitionFinished = false;
        transitionStartTime = Time.time;
        going = true;

        //var objectname = GameObject.FindWithTag("CinematicBG");
        //var objectname = GameObject.Find(whichSprite.name+"Clone");
        //print(objectname.name);
        print(currentSprite);

        while (transitionFinished == false)
        {
            
            if (going)
            {
                transitionJourneyLength = Vector3.Distance(new Vector3(0, 0, 0), popScale);
                transitionDistCovered = (Time.time - transitionStartTime) * popSpeed;
                transitionPercent = transitionDistCovered / transitionJourneyLength;
                currentSprite.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), popScale, transitionPercent);

                if (currentSprite.transform.localScale == popScale)
                {
                    going = false;
                    transitionStartTime = Time.time;
                }
            }
            if (!going)
            {
                transitionJourneyLength = Vector3.Distance(popScale, new Vector3(0, 0, 0));
                transitionDistCovered = (Time.time - transitionStartTime) * popSpeed;
                transitionPercent = transitionDistCovered / transitionJourneyLength;
                currentSprite.transform.localScale = Vector3.Lerp(popScale, new Vector3(1, 1, 1), transitionPercent);
                if (currentSprite.transform.localScale == new Vector3(1, 1, 1))
                {
                    transitionFinished = true;
                }
            }

            //yield return null;
        }
        
    }
}
