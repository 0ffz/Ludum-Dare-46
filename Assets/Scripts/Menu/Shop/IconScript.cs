using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconScript : MonoBehaviour, IDragHandler {
    Camera _cam;
    private RawImage _image;

    void Start() {
        _image = GetComponent<RawImage>();
        _cam = Camera.main;
    }

    public FreeMovable attachedItem;

    private FreeMovable _itemCreated;
    private bool _startedDragging;

    /**
     * As long as we're dragging we'll call the OnMouseDrag method of the instantiated FreeMovable.
     * We hide our sprite here to
     */
    public void OnDrag(PointerEventData eventData) {
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (_itemCreated == null)
            _itemCreated = Instantiate(attachedItem, new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
        else
            _itemCreated.OnMouseDrag();
        GameItem.CurrentlyActive = _itemCreated.gameObject;
        _image.enabled = false;
        _startedDragging = true;
    }

    //Destroy this object once we let go
    private void Update() {
        if (_startedDragging && Input.GetMouseButtonUp(0)) {
            _itemCreated.OnMouseUp();
            Destroy(gameObject);
        }
    }
}