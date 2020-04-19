using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnPlanComplete : MonoBehaviour {
    void Start() {
        GameState.Instance.OnPlanComplete += () => gameObject.SetActive(false);
    }
}