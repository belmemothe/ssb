using UnityEngine;
using System.Collections;

public class rotObj : MonoBehaviour

{
    public float rotSpeed = 600;

    public Transform worldCenter;

    private void Start()
    {
        worldCenter.GetComponent<Transform>();
    }
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        worldCenter.Rotate(Vector3.up, rotX);
        worldCenter.Rotate(Vector3.right, -rotY);
    }
}