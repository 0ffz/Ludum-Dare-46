using System;
using Events;
using UnityEngine;

public class DeathMenu : MonoBehaviour {
    private void Start() {
        GameState.Instance.OnGameLose += GameOver;
        gameObject.SetActive(false);
        Debug.Log("Started");
    }

    private void OnEnable() {
        Debug.Log("Started1");
    }

    public void GameOver() {
        gameObject.SetActive(true);
    }

    public void Restart() {
        GameState.RestartStage();
    }
}