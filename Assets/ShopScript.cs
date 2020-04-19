using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject imageList;
    public GameObject rawImageTemplate;

    // round[row].items[column]

    // Start is called before the first frame update
    void Start()
    {
        GameState.Instance.OnGameStart += CreateMenu;

        Debug.Log(GameState.Instance.Round);
        foreach (GameObject item in GameState.Instance.rounds[GameState.Instance.Round - 1].items) {
            SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
            GameObject newItem = Instantiate(rawImageTemplate);
            RawImage riUI = newItem.GetComponent<RawImage>();
            riUI.texture = sr.sprite.texture;
            IconScript iconscript = newItem.GetComponent<IconScript>();
            iconscript.attachedItem = item;
            riUI.transform.SetParent(imageList.transform, false);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateMenu() {
        /*
        foreach(GameObject item in rounds[GameState.Instance.Round - 1].items) {
            SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
            GameObject newItem = Instantiate(rawImageTemplate);
            RawImage riUI = newItem.GetComponent<RawImage>();
            riUI.texture = sr.sprite.texture;
            riUI.transform.SetParent(imageList.transform, false);
        }
        */
    }

    public void transferObject() {
        Debug.Log("Button pressed");
    }


}
