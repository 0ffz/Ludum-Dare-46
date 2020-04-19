using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundText : MonoBehaviour {
    // Start is called before the first frame update
    void OnEnable() {
        GameState.Instance.OnRoundStart += () => {
            GetComponent<TextMeshProUGUI>().text = "Round " + GameState.Instance.Round + "/" + GameState.Instance.rounds;
        };
    }
}