using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public float scrollSens;
    public float minCamSize;
    public float maxCamSize;
    private Vector3 _initialPosition;

    private Vector3 MousePos {
        get {
            var cam = _cam.ScreenToWorldPoint(Input.mousePosition);
            cam.z = -10;
            return cam;
        }
    }

    public SpriteRenderer background;

    private Camera _cam;
    private bool _ignoreInput = true;

    private void OnEnable() {
        GameState.Instance.OnRoundStart += () => {
            _ignoreInput = true;
            var pos = GameState.CurrentRound.boxLocation.position;
            var originalPos = transform.position;
            pos.z = originalPos.z;
            transform.DOMove(pos, 1.5f).SetEase(Ease.InOutCubic).OnComplete(() => {
                transform.DOMove(originalPos, 1).SetEase(Ease.InOutCubic).OnComplete(EnableMovement);
            });
        };
    }

    // Start is called before the first frame update
    void Start() {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (_ignoreInput) return;


        if (Input.GetMouseButtonDown(1)) {
            _initialPosition = MousePos;
            return;
        }

        // background.bounds.min
        if (transform.position.x > background.bounds.max.x) {
            _ignoreInput = true;
            transform.DOMoveX(background.bounds.max.x - 5, 0.3f).OnComplete(EnableMovement);
        }
        else if (transform.position.x < background.bounds.min.x) {
            _ignoreInput = true;
            transform.DOMoveX(background.bounds.min.x + 5, 0.3f).OnComplete(EnableMovement);
        }
        if (transform.position.y > background.bounds.max.y) {
            _ignoreInput = true;
            transform.DOMoveY(background.bounds.max.y - 5, 0.3f).OnComplete(EnableMovement);
        }
        else if (transform.position.y < background.bounds.min.y) {
            _ignoreInput = true;
            transform.DOMoveY(background.bounds.min.y + 5, 0.3f).OnComplete(EnableMovement);
        }

        if (Input.GetMouseButton(1))
            transform.position += _initialPosition - MousePos;

        _cam.orthographicSize = Mathf.Clamp(_cam.orthographicSize + Input.mouseScrollDelta.y * scrollSens * -1,
            minCamSize, maxCamSize);
    }

    void EnableMovement() {
        _ignoreInput = false;
        _initialPosition = MousePos;
    }
}