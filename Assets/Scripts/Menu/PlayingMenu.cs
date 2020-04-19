using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingMenu : MonoBehaviour {
    private void Start() {
        GameState.Instance.OnGameWin += () => {
            transform.GetChild(0).gameObject.SetActive(true);
        };
    }

    public void NextStage() {
        GameState.LoadNextStage();
    }

    public void Restart() {
        GameState.RestartStage();
    }
}