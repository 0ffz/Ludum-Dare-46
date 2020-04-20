using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCurrentRound : MonoBehaviour {
    // Start is called before the first frame update
    void OnEnable() {
        GameState.Instance.OnRoundStart += () => {
            GetComponent<TextMeshProUGUI>().text = "Round " + GameState.Instance.Round + "/" + GameState.Instance.MaxRounds;
        };
    }
}