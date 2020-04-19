﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconScript : MonoBehaviour, IDragHandler {

    Camera cam;

    void Start() {
        cam = Camera.main;
    }



    public GameObject attachedItem;

    public void OnDrag(PointerEventData eventData) {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(attachedItem,  new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
        Destroy(gameObject);
    }
}
