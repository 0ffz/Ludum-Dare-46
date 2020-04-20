using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundText : MonoBehaviour {
    // Start is called before the first frame update
    void OnEnable() {
        print("Enabling text");
        GameState.Instance.OnRoundStart += () => {
            print("Updating text!");
            GetComponent<TextMeshProUGUI>().text = "Round " + GameState.Instance.Round + "/" + GameState.Instance.MaxRounds;
        };
    }
}