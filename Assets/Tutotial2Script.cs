using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutotial2Script : MonoBehaviour
{
    public GameObject[] textObjects;

    void OnEnable() {
        GameState.Instance.OnRoundStart += BeginText;
        GameState.Instance.OnPlanComplete += NumberText;
    }

    void BeginText() {
        if (GameState.Instance.Round == 1) {
            textObjects[0].SetActive(true);
            textObjects[1].SetActive(true);
        }
        else {
            textObjects[0].SetActive(false);
        }
    }

    void NumberText() {
        if (GameState.Instance.Round == 1) {
            textObjects[1].SetActive(false);
        }
    }
}
