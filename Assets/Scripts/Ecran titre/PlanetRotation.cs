using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{

    public float rotSpeed = 0;
    float y;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y += Time.deltaTime * rotSpeed;
        x += Time.deltaTime * rotSpeed * 0.3f;

        transform.rotation = Quaternion.Euler(x, y, 0);
    }
}
