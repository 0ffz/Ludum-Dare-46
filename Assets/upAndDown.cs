using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upAndDown : MonoBehaviour {
    public float delta = 1.5f; // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        // Move the saw 
        Vector3 myVectorSaw = startPos;
        myVectorSaw.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = myVectorSaw;
        // Spin the sasw 
        transform.Rotate(Vector3.forward * 35);
    }
}