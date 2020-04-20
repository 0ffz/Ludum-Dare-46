using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconScript : MonoBehaviour, IDragHandler {
    Camera _cam;
    [NonSerialized] public TextMeshProUGUI ItemsLeftText;
    private RawImage _image;

    public FreeMovable attachedItem;

    private FreeMovable _itemCreated;
    private bool _startedDragging;
    public RawImage rawImageIcon;

    void Start() {
        _image = GetComponent<RawImage>();
        _cam = Camera.main;
    }

    public void SetIcon() {
        rawImageIcon = transform.GetChild(0).GetComponent<RawImage>();
        if(attachedItem.icon == null) Destroy(rawImageIcon.gameObject);
        else rawImageIcon.texture = attachedItem.icon;
    }

    /**
     * As long as we're dragging we'll call the OnMouseDrag method of the instantiated FreeMovable.
     * We hide our sprite here to
     */
    public void OnDrag(PointerEventData eventData) {
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (_itemCreated == null) {
            if (GameState.CurrentRound.itemPicks <= 0) return;
            _itemCreated = Instantiate(attachedItem, new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
            int items = --GameState.CurrentRound.itemPicks;
            ItemsLeftText.text = items + " Left";
            if (GameState.CurrentRound.itemPicks <= 0)
                transform.parent.parent.parent.GetComponent<ShopScript>().Hide();
        }
        else {
            _itemCreated.Locked = false;
            _itemCreated.OnMouseDrag();
        }

        GameItem.CurrentlyActive = _itemCreated.gameObject;
        _image.enabled = false;
        if(rawImageIcon != null)
            rawImageIcon.enabled = false;
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