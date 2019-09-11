using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeGauge : MonoBehaviour {

    private float originalScale = 0f;
    //private float currentScale = 0f;
    private float percent = 0f;


	// Use this for initialization
	void Start () {
        originalScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {

        percent = Drawingcontroller.globalTimeLeft / Drawingcontroller.originalTimeLeft;
        transform.localScale = new Vector3(originalScale*percent, 1, 1);

	}
}
