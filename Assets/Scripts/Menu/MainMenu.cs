using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    public class MainMenu : MonoBehaviour {
        public void StartGame() {
            GameState.LoadLatestStage();
        }

        public void QuitGame() {
            Application.Quit();
        }

        public void RestartGame() {
            PlayerPrefs.DeleteKey("latestStage");
            GameState.LoadLatestStage();
        }
    }
}