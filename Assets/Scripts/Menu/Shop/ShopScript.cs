using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
    public GameObject imageList;
    public GameObject rawImageTemplate;
    public TextMeshProUGUI itemsLeftText;
    private float _startX;

    void OnEnable() {
        //TODO OnEnable gets called every time the object re-enables, not sure if it registers events twice
        GameState.Instance.OnRoundStart += CreateItems; 
        GameState.Instance.OnPlanComplete += () => {
            Hide();
        }; 
        _startX = transform.position.x;
        print("onenable was called!");
    }

    void CreateItems() {
        itemsLeftText.text = GameState.CurrentRound.itemPicks + " Left";
        foreach (Transform child in imageList.transform) Destroy(child.gameObject);
        Show();
        
        foreach (FreeMovable item in GameState.Instance.rounds[GameState.Instance.Round - 1].items) {
            if(item == null) continue;
            SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
            GameObject newItem = Instantiate(rawImageTemplate);
            RawImage riUI = newItem.GetComponent<RawImage>();
            riUI.texture = sr.sprite.texture;
            IconScript iconscript = newItem.GetComponent<IconScript>();
            iconscript.attachedItem = item;
            iconscript.ItemsLeftText = itemsLeftText;
            riUI.transform.SetParent(imageList.transform, false);
        }
    }

    public void Show() {
        transform.DOMoveX(_startX, 1).SetEase(Ease.InOutCubic);
    }

    public void Hide() {
        transform.DOMoveX(-100, 1).SetEase(Ease.InOutCubic);
    }
}