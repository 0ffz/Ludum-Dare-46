using UnityEngine;

public class Mover : GameItem {
    public float trackLength;

    public enum direction {
        Horizontal,
        Vertical
    }

    public direction dir;
    Vector3 relativePos;
    Vector3 initPos;
    LineRenderer lr;
    Camera cam;
    Rigidbody2D rb2d;


    void freemove() {
        initPos = transform.position;
        lr = GetComponentInChildren<LineRenderer>();
        lr.useWorldSpace = true;
        cam = Camera.main;

        //Draw Line
        if (dir == direction.Vertical) {
            lr.SetPosition(0, (Vector3.up * -trackLength) + initPos);
            lr.SetPosition(1, (Vector3.up * trackLength) + initPos);
        }
        else {
            lr.SetPosition(0, (Vector3.right * -trackLength) + initPos);
            lr.SetPosition(1, (Vector3.right * trackLength) + initPos);
        }
    }

    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        GameState.Instance.OnPlanComplete += freemove;

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
        if (dir == direction.Horizontal) {
            rb2d.MovePosition(new Vector2(
                Mathf.Clamp(mousePos.x + relativePos.x, -trackLength + initPos.x, trackLength + initPos.x),
                initPos.y));
        }
        else {
            rb2d.MovePosition( new Vector2(initPos.x,
                Mathf.Clamp(mousePos.y + relativePos.y, -trackLength + initPos.y, trackLength + initPos.y)));
        }
    }
}