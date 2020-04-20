using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
    public GameObject imageList;
    public GameObject rawImageTemplate;

    void OnEnable() {
        GameState.Instance.OnRoundStart += CreateItems;
    }

    void CreateItems() {
        foreach (FreeMovable item in GameState.Instance.rounds[GameState.Instance.Round - 1].items) {
            if(item == null) continue;
            SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
            GameObject newItem = Instantiate(rawImageTemplate);
            RawImage riUI = newItem.GetComponent<RawImage>();
            riUI.texture = sr.sprite.texture;
            IconScript iconscript = newItem.GetComponent<IconScript>();
            iconscript.attachedItem = item;
            riUI.transform.SetParent(imageList.transform, false);
        }
    }
}