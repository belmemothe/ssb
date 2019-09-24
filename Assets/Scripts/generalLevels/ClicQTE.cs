using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicQTE : MonoBehaviour
{
    public int TimerQTE = 3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("oui");
        }
    }
}
