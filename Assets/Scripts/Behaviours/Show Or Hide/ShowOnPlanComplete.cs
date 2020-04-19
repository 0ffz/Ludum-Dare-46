using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnPlanComplete : MonoBehaviour {
    public bool hideOnRoundStart = true;

    void Start() {
        gameObject.SetActive(false);
        GameState.Instance.OnPlanComplete += () => gameObject.SetActive(true);
        if (hideOnRoundStart)
            gameObject.AddComponent<HideOnRoundStart>();
    }
}