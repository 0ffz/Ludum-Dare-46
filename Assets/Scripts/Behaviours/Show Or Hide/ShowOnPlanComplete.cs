using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnPlanComplete : MonoBehaviour {
    void Start() {
        gameObject.SetActive(false);
        GameState.Instance.OnPlanComplete += () => gameObject.SetActive(true);
    }
}