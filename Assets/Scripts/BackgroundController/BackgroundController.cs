using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Header("Background")]
    public GameObject Background1;
    public float background1OffsetX = 0;
    public float background1OffsetY = 0;
    public GameObject Background2;
    public float background2OffsetX = 0;
    public float background2OffsetY = 0;
    public GameObject Background3;
    public float background3OffsetX = 0;
    public float background3OffsetY = 0;
    public GameObject BackgroundElement1;
    public float backgroundElement1OffsetX = 0;
    public float backgroundElement1OffsetY = 0;
    public GameObject BackgroundElement2;
    public float backgroundElement2OffsetX = 0;
    public float backgroundElement2OffsetY = 0;
    public GameObject BackgroundElement3;
    public float backgroundElement3OffsetX = 0;
    public float backgroundElement3OffsetY = 0;
    public GameObject BackgroundElement4;
    public float backgroundElement4OffsetX = 0;
    public float backgroundElement4OffsetY = 0;
    public GameObject BackgroundElement5;
    public float backgroundElement5OffsetX = 0;
    public float backgroundElement5OffsetY = 0;
    [Header("Middleground")]
    public GameObject MiddlegoundElement1;
    public float MiddlegoundElement1OffsetX = 0;
    public float MiddlegoundElement1OffsetY = 0;
    public GameObject MiddlegoundElement2;
    public float MiddlegoundElement2OffsetX = 0;
    public float MiddlegoundElement2OffsetY = 0;
    public GameObject MiddlegoundElement3;
    public float MiddlegoundElement3OffsetX = 0;
    public float MiddlegoundElement3OffsetY = 0;
    [Header("Foreground")]
    public GameObject Foreground;
    public float ForegroundOffsetX = 0;
    public float ForegroundOffsetY = 0;
    public GameObject ForegroundElement1;
    public float ForegroundElement1OffsetX = 0;
    public float ForegroundElement1OffsetY = 0;
    public GameObject ForegroundElement2;
    public float ForegroundElement2OffsetX = 0;
    public float ForegroundElement2OffsetY = 0;
    public GameObject ForegroundElement3;
    public float ForegroundElement3OffsetX = 0;
    public float ForegroundElement3OffsetY = 0;
    public GameObject ForegroundElement4;
    public float ForegroundElement4OffsetX = 0;
    public float ForegroundElement4OffsetY = 0;
    public GameObject ForegroundElement5;
    public float ForegroundElement5OffsetX = 0;
    public float ForegroundElement5OffsetY = 0;


    void Start()
    {
        if (Background1 != null)
        {
            Instantiate(Background1, new Vector3(0 + background1OffsetX, 0 + background1OffsetY, 0.5f), Quaternion.identity);
        }
        if (Background2 != null)
        {
            Instantiate(Background2, new Vector3(0 + background2OffsetX, 0 + background2OffsetY, 0.4f), Quaternion.identity);
        }
        if (Background3 != null)
        {
            Instantiate(Background3, new Vector3(0 + background3OffsetX, 0 + background3OffsetY, 0.3f), Quaternion.identity);
        }

        if (BackgroundElement1 != null)
        {
            Instantiate(BackgroundElement1, new Vector3(-3.5f + backgroundElement1OffsetX, 6 + backgroundElement1OffsetY, 0.1f), Quaternion.identity);
        }
        if (BackgroundElement2 != null)
        {
            Instantiate(BackgroundElement2, new Vector3(3.5f + backgroundElement2OffsetX, 6 + backgroundElement2OffsetY, 0.1f), Quaternion.identity);
        }
        if (BackgroundElement3 != null)
        {
            Instantiate(BackgroundElement3, new Vector3(0 + backgroundElement3OffsetX, 2.5f + backgroundElement3OffsetY, 0.1f), Quaternion.identity);
        }
        if (BackgroundElement4 != null)
        {
            Instantiate(BackgroundElement4, new Vector3(-3.5f + backgroundElement4OffsetX, -1 + backgroundElement4OffsetY, 0.1f), Quaternion.identity);
        }
        if (BackgroundElement5 != null)
        {
            Instantiate(BackgroundElement5, new Vector3(3.5f + backgroundElement5OffsetX, -1 + backgroundElement5OffsetY, 0.1f), Quaternion.identity);
        }

        if (MiddlegoundElement1 != null)
        {
            Instantiate(MiddlegoundElement1, new Vector3(-3.5f + MiddlegoundElement1OffsetX, -4 + MiddlegoundElement1OffsetY, -0.1f), Quaternion.identity);
        }
        if (MiddlegoundElement2 != null)
        {
            Instantiate(MiddlegoundElement2, new Vector3(0 + MiddlegoundElement2OffsetX, -4 + MiddlegoundElement2OffsetY, -0.1f), Quaternion.identity);
        }
        if (MiddlegoundElement3 != null)
        {
            Instantiate(MiddlegoundElement3, new Vector3(3.5f + MiddlegoundElement3OffsetX, -4 + MiddlegoundElement3OffsetY, -0.1f), Quaternion.identity);
        }

        if (Foreground != null)
        {
            Instantiate(Foreground, new Vector3(0 + ForegroundOffsetX, -7 + ForegroundOffsetY, 0), Quaternion.identity);
        }
        if (ForegroundElement1 != null)
        {
            Instantiate(ForegroundElement1, new Vector3(-4 + ForegroundElement1OffsetX, -8 + ForegroundElement1OffsetY, -0.2f), Quaternion.identity);
        }
        if (ForegroundElement2 != null)
        {
            Instantiate(ForegroundElement2, new Vector3(-2 + ForegroundElement2OffsetX, -7 + ForegroundElement2OffsetY, -0.2f), Quaternion.identity);
        }
        if (ForegroundElement3 != null)
        {
            Instantiate(ForegroundElement3, new Vector3(0 + ForegroundElement3OffsetX, -8 + ForegroundElement3OffsetY, -0.2f), Quaternion.identity);
        }
        if (ForegroundElement4 != null)
        {
            Instantiate(ForegroundElement4, new Vector3(2 + ForegroundElement4OffsetX, -7 + ForegroundElement4OffsetY, -0.2f), Quaternion.identity);
        }
        if (ForegroundElement5 != null)
        {
            Instantiate(ForegroundElement5, new Vector3(4 + ForegroundElement5OffsetX, -8 + ForegroundElement5OffsetY, -0.2f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
