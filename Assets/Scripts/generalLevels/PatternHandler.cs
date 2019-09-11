using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternHandler : MonoBehaviour {

    public Vector2[] dots;
    public GameObject dot;

    private int dotCreator = 0;
    private int dotsSize;

    public static int dotsLength;
    


    //Use this for initialization
	void Start () {

        dotsLength = dots.Length;
		
	}
	
	// Update is called once per frame
	void Update () {


        //Places and names all of the pattern's dots
        dotsSize = dots.Length;

        if (dotCreator < dotsSize)
        {

            var newDot = Instantiate(dot, dots[dotCreator], Quaternion.identity);
            newDot.gameObject.name = "Dot" + dotCreator + "";

            if (dotCreator == dotsSize - 1)
            {
                SpriteRenderer image = newDot.gameObject.GetComponent<SpriteRenderer>();
                image.enabled = false;
            }
            dotCreator++;

        }



    }

    public void DotDestroy()
    {
        dotCreator = 0;
        while (dotCreator < dotsSize)
        {
            Destroy(GameObject.Find("Dot" + dotCreator + ""));
            dotCreator++;
        }

        Destroy(GameObject.Find("Line(Clone)"));
    }
}
