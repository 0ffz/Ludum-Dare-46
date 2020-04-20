using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovable : GameItem {
    Camera cam;
    Vector3 relativePos;
    Rigidbody2D rb2d;
    bool InitialMove;
    bool hasMoved;
    private Mover mover;

    void Start() {
        InitialMove = true;
        hasMoved = false;
        cam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("isInitialMove", 0.1f);
        mover = gameObject.GetComponent<Mover>();
    }

    void isInitialMove() {
        if (!hasMoved) {
            InitialMove = false;
        }
    }

    private void Update() {
        if (Input.GetMouseButton(0) && InitialMove) {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            rb2d.MovePosition(mousePos + relativePos);
            hasMoved = true;
        }
        else {
            InitialMove = false;
        }
    }

    private void OnMouseDown() {
        if (!Allowed) return;
        relativePos = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag() {
        if (!Allowed) return;
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb2d.MovePosition(mousePos + relativePos);
        if(mover != null)
            mover.InitPos = transform.position;
    }
}