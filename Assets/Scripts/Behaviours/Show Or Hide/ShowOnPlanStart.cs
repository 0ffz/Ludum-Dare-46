using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnPlanStart : MonoBehaviour {
    void Start() {
        gameObject.SetActive(false);
        GameState.Instance.OnPlanningStart += () => gameObject.SetActive(true);
    }
}