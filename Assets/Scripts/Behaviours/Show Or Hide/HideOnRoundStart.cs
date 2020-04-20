using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnRoundStart : MonoBehaviour {
    void OnEnable() {
        GameState.Instance.OnRoundStart += () => gameObject.SetActive(false);
    }
}