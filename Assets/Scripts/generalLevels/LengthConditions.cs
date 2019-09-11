using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthConditions : MonoBehaviour {

    private SpriteRenderer image;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {


        if (Drawingcontroller.dotProgression >= PatternHandler.dotsLength)
        {
            image.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (gameObject.name == Drawingcontroller.currentDotName)
        {
            Drawingcontroller.successProgression = 1;

        }


    }
}
