using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Header("Background")]
    public GameObject Background1;
    public GameObject Background2;
    public GameObject Background3;
    public GameObject BackgroundElement1;
    public GameObject BackgroundElement2;
    public GameObject BackgroundElement3;
    public GameObject BackgroundElement4;
    public GameObject BackgroundElement5;
    [Header("Middleground")]
    public GameObject MiddlegoundElement1;
    public GameObject MiddlegoundElement2;
    public GameObject MiddlegoundElement3;
    [Header("Foreground")]
    public GameObject Foreground;
    public GameObject ForegroundElement1;
    public GameObject ForegroundElement2;
    public GameObject ForegroundElement3;
    public GameObject ForegroundElement4;
    public GameObject ForegroundElement5;

    void Start()
    {
        if (Background1 != null)
        {
            Instantiate(Background1, new Vector3(0, 0, 0.5f), Quaternion.identity);
        }
        if (Background2 != null)
        {
            Instantiate(Background2, new Vector3(0, 0, 0.4f), Quaternion.identity);
        }
        if (Background3 != null)
        {
            Instantiate(Background3, new Vector3(0, 0, 0.3f), Quaternion.identity);
        }

        if (BackgroundElement1 != null)
        {
            Instantiate(BackgroundElement1, new Vector3(-3.5f, 6 ,0.1f), Quaternion.identity);
        }
        if (BackgroundElement2 != null)
        {
            Instantiate(BackgroundElement2, new Vector3(3.5f, 6, 0.1f), Quaternion.identity);
        }
        if (BackgroundElement3 != null)
        {
            Instantiate(BackgroundElement3, new Vector3(0, 2.5f, 0.1f), Quaternion.identity);
        }
        if (BackgroundElement4 != null)
        {
            Instantiate(BackgroundElement4, new Vector3(-3.5f, -1, 0.1f), Quaternion.identity);
        }
        if (BackgroundElement5 != null)
        {
            Instantiate(BackgroundElement5, new Vector3(3.5f, -1, 0.1f), Quaternion.identity);
        }

        if (MiddlegoundElement1 != null)
        {
            Instantiate(MiddlegoundElement1, new Vector3(-3.5f, -4, -0.1f), Quaternion.identity);
        }
        if (MiddlegoundElement2 != null)
        {
            Instantiate(MiddlegoundElement2, new Vector3(0, -4, -0.1f), Quaternion.identity);
        }
        if (MiddlegoundElement3 != null)
        {
            Instantiate(MiddlegoundElement3, new Vector3(3.5f, -4, -0.1f), Quaternion.identity);
        }

        if (Foreground != null)
        {
            Instantiate(Foreground, new Vector3(0, -7, 0), Quaternion.identity);
        }
        if (ForegroundElement1 != null)
        {
            Instantiate(ForegroundElement1, new Vector3(-4, -8, -0.2f), Quaternion.identity);
        }
        if (ForegroundElement2 != null)
        {
            Instantiate(ForegroundElement2, new Vector3(-2, -7, -0.1f), Quaternion.identity);
        }
        if (ForegroundElement3 != null)
        {
            Instantiate(ForegroundElement3, new Vector3(0, -8, -0.2f), Quaternion.identity);
        }
        if (ForegroundElement4 != null)
        {
            Instantiate(ForegroundElement4, new Vector3(2, -7, -0.1f), Quaternion.identity);
        }
        if (ForegroundElement5 != null)
        {
            Instantiate(ForegroundElement5, new Vector3(4, -8, -0.2f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
