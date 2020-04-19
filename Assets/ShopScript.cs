using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
    public GameObject imageList;
    public GameObject rawImageTemplate;

    void OnEnable() {
        GameState.Instance.OnRoundStart += CreateItems;
    }

    void CreateItems() {
        print("Creating items");
        foreach (GameObject item in GameState.Instance.rounds[GameState.Instance.Round - 1].items) {
            SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
            GameObject newItem = Instantiate(rawImageTemplate);
            RawImage riUI = newItem.GetComponent<RawImage>();
            riUI.texture = sr.sprite.texture;
            riUI.transform.SetParent(imageList.transform, false);
        }
    }
}