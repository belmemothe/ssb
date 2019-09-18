using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBPM : MonoBehaviour
{
    [Header("gestion de l'animation")]
    public Vector3 minScale;
    public Vector3 maxScale;
    public int bpm = 0;
    //la vitesse générale
    public float speed = 0.1f;
    [Header("In devloppement (debug)")]
    public float baseValue = 1;
    //le temps ou il ne bouge pas en position dégonfler
    public int durationPause = 2;
    public bool havePause = true;
    bool state = false;
    void Start()
    {
        //Debug.Log(minScale);
        minScale = transform.localScale;
        StartCoroutine(PauseLOL());
    }

    private void Update()
    {
        //cos((t * pi * (s / 60)) mod pi)
        //float baseValue = Mathf.Cos(((Time.time * Mathf.PI) * (bpm / 60f)) % Mathf.PI);

    }

    public IEnumerator PauseLOL()
    {
        Debug.Log("ENTER ENTER MISSION");
        while (true)
        {
           //décocher le bool havePause pour ne pas utiliser ce if
            if (transform.localScale == minScale && !state && havePause)
            {
                //cette partie est pour la "pause" pour l'animation.
                //!\\ ne fonctionne pas encore. Il frise
                transform.localScale = minScale;
                yield return new WaitForSeconds(durationPause);
                //baseValue =-2f;
                state = true;


            }
            else
            {
                baseValue = Mathf.Sin((Time.time * Mathf.PI) * (bpm * 2 / 60f)) * speed;
                transform.localScale = Vector3.Lerp(minScale, maxScale, baseValue);
                yield return null;
            }
            

            if (state)
            {
                state = false;
            }
        }
    }
    /* Ce code est vieux et ne doit pas être utiliser
    IEnumerator Start ()
    {
        minScale = transform.localScale;
        while (repeatable)
        {
            yield return RepeatLerp(minScale, maxScale, duration);
            yield return RepeatLerp(maxScale, minScale, duration);
            yield return RepeatLerp(minScale, minScale, durationPause);
        }

    }
    */
    /*
    public IEnumerator RepeatLerp (Vector3 a, Vector3 b, float time)
    {
        //a = départ
        //b = arrivée
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            // change la taille
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        } 
        
        Debug.Log(baseValue);
        Debug.Log(1.0f/Time.fixedDeltaTime);
    }
    */
}