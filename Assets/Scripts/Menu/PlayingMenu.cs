using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingMenu : MonoBehaviour {
    private void Start() {
        GameState.Instance.OnGameWin += () => {
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Win time boys");
        };
    }

    public void NextStage() {
        GameState.LoadNextStage(SceneManager.GetActiveScene());
    }

    public void Restart() {
        GameState.LoadStage(SceneManager.GetActiveScene().buildIndex);
    }
}