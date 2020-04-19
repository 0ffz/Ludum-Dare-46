using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnPlanStart : MonoBehaviour {
    void Start() {
        GameState.Instance.OnPlanningStart += () => gameObject.SetActive(false);
    }
}