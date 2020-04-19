using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    Vector3 initialPosition;
    Vector3 mousePos;
    Camera cam;
    public float scrollSens;
    public float minCamSize;
    public float maxCamSize;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1))
            transform.position += initialPosition - mousePos;
        else
            initialPosition = mousePos;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + Input.mouseScrollDelta.y * scrollSens * -1, minCamSize, maxCamSize);
    }
}
