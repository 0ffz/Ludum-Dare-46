using UnityEngine;

public class PlayingMenu : MonoBehaviour {
    public GameObject DeathMenu;

    private void Start() {
        GameState.Instance.OnGameWin += () => { transform.GetChild(0).gameObject.SetActive(true); };
    }

    public void NextRound() {
        if (GameState.Instance.Round >= GameState.Instance.MaxRounds)
            GameState.LoadNextStage();
        else {
            GameState.Instance.Round++;
            GameState.Instance.StartRound();
        }
    }

    public void Restart() {
        DeathMenu.SetActive(true);
    }
}