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
        if(GameState.Instance.Round > GameState.Instance.rounds)
            GameState.LoadNextStage();
        else {
            GameState.Instance.Round++;
            GameState.Instance.StartPlanning();
        }
    }

    public void Restart() {
        GameState.RestartStage();
    }
}