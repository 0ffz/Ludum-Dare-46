using UnityEngine;

public class FreeMovable : GameItem {
    private Camera _cam;
    private Vector3 _relativePos;
    private Rigidbody2D _rb2d;
    private AxisMovable _axisMovable;

    void Start() {
        _cam = Camera.main;
        _rb2d = GetComponent<Rigidbody2D>();
        _axisMovable = gameObject.GetComponent<AxisMovable>();
    }

    private new void OnMouseDown() {
        if (!Allowed) return;
        _relativePos = transform.position - _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseDrag() {
        if (!Allowed) return;
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        _rb2d.MovePosition(mousePos + _relativePos);
        if (_axisMovable != null) {
            _axisMovable.InitPos = transform.position;
            _axisMovable.DrawLine();
        }
    }
}