using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour {
    private bool _rockTouchedPlatform = false, _hitTargetedPosition = false;
    private float _ogPosition, _targetedPosition;
    public float speedStart = 0.5f;
    public float speedGoBack = 1f;
    public float moveAmount = 4f;

    void Start() {
        _ogPosition = transform.position.x;
        _targetedPosition = _ogPosition + moveAmount;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (_rockTouchedPlatform) return;
        _rockTouchedPlatform = true;
        transform.DOMoveX(_targetedPosition, speedStart).OnComplete(() => {
            transform.DOMoveX(_ogPosition, speedGoBack).OnComplete(() => _rockTouchedPlatform = false);
        });
    }
}