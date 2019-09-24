using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        Sc_EventManager.StartListening("PopUp", Test);
    }

 
    private void OnDisable()
    {
        Sc_EventManager.StopListening("PopUp", Test);
    }

    private void Test(float obj)
    {
        throw new NotImplementedException();
    }

}
