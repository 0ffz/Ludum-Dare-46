using System;
using UnityEngine;

public class Mover : GameItem {
    public float trackLength;

    public enum Direction {
        Horizontal,
        Vertical
    }

    public Direction dir;
    Vector3 relativePos;
    [NonSerialized] public Vector3 InitPos;
    LineRenderer lr;
    Camera cam;
    Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        InitPos = transform.position;
        lr = GetComponentInChildren<LineRenderer>();
        lr.useWorldSpace = true;
        cam = Camera.main;
        
        DrawLine();
    }

    private void DrawLine() {
        //Draw Line
        if (dir == Direction.Vertical) {
            lr.SetPosition(0, (Vector3.up * -trackLength) + InitPos);
            lr.SetPosition(1, (Vector3.up * trackLength) + InitPos);
        }
        else {
            lr.SetPosition(0, (Vector3.right * -trackLength) + InitPos);
            lr.SetPosition(1, (Vector3.right * trackLength) + InitPos);
        }
    }

    // Gets position relative to fan
    private void OnMouseDown() {
        if (!Allowed) return;
        relativePos = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Moves fan to the cursor
    private void OnMouseDrag() {
        if (!Allowed) return;
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (dir == Direction.Horizontal) {
            rb2d.MovePosition(new Vector2(
                Mathf.Clamp(mousePos.x + relativePos.x, -trackLength + InitPos.x, trackLength + InitPos.x),
                InitPos.y));
        }
        else {
            rb2d.MovePosition(new Vector2(InitPos.x,
                Mathf.Clamp(mousePos.y + relativePos.y, -trackLength + InitPos.y, trackLength + InitPos.y)));
        }
        DrawLine();
    }
}