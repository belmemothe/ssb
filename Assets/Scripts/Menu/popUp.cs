using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour

{
    bool isOpen = false;

    void OnGUI() //I think this must be used on the camera so you may have to reference a gui controller on the camera
    {
        if (isOpen) //Is it Open?
        {
            if (GUI.Button(new Rect(10, 10, 100, 50), "Yes")) //Display and use the Yes button
            {
                Debug.Log("Yes");
                isOpen = false;
            }
        }
    }

    void OnMouseDown() //Get the mouse click
    {
        isOpen = true;   //Set the buttons to appear
    }
}
