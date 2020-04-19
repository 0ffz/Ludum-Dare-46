using UnityEngine;

public class PlayingMenu : MonoBehaviour {
    private void Start() {
        GameState.Instance.OnGameWin += () => { transform.GetChild(0).gameObject.SetActive(true); };
    }

    public void NextRound() {
        if (GameState.Instance.Round >= GameState.Instance.rounds)
            GameState.LoadNextStage();
        else {
            GameState.Instance.Round++;
            GameState.Instance.StartRound();
        }
    }

    public void Restart() {
        GameState.RestartStage();
    }
}