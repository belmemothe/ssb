using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linedrawing : MonoBehaviour {

    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> mousePositions;

    public static float lineLength = 0f;
    public bool isActive = false;
    public static bool globalisActive = false;



	// Use this for initialization
	void Start () {
        globalisActive = isActive;
	}

    // Update is called once per frame
    void Update()
    {
        if (globalisActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();

            }

            if (Input.GetMouseButton(0))
            {
                Vector2 tempMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempMousePos, mousePositions[mousePositions.Count - 1]) > .1f)
                {
                    UpdateLine(tempMousePos);
                    lineLength += .1f;

                }
            }
        }
        

    }

    void CreateLine(){ 

        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        mousePositions.Clear();
        mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        lineRenderer.SetPosition(0, mousePositions[0]);
        lineRenderer.SetPosition(1, mousePositions[1]);

        edgeCollider.points = mousePositions.ToArray();


    }


    void UpdateLine(Vector2 newMousePos)
    {

        mousePositions.Add(newMousePos);

        if (lineRenderer != null)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newMousePos);
            edgeCollider.points = mousePositions.ToArray();
        }

        

    }
}
