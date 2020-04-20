using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRocksEntered : MonoBehaviour {
    // Start is called before the first frame update
    void OnEnable() {
        GameState.Instance.OnRockEnter += UpdateText;
        GameState.Instance.OnRoundStart += UpdateText;
    }

    private void UpdateText() {
        GetComponent<TextMeshProUGUI>().text = GameState.Instance.RocksEntered + "/" + GameState.Instance.TotalRocksToWin;
    }
}