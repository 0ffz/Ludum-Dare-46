using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnRoundStart : MonoBehaviour {
    void OnEnable() {
        print("Adding to OnRoundStart for HideOnRoundStart");
        GameState.Instance.OnRoundStart += () => gameObject.SetActive(false);
    }
}