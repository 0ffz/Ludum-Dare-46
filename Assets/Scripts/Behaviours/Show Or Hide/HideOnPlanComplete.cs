using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnPlanComplete : MonoBehaviour {
    public bool showOnRoundStart = true;
    
    void Start() {
        GameState.Instance.OnPlanComplete += () => gameObject.SetActive(false);
        if(showOnRoundStart)
            gameObject.AddComponent<ShowOnRoundStart>();
    }
}