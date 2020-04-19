using System;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * The status of the game. Follows a singleton pattern, meaning only one instance of this object should
 * ever exist. The reason we don't use static here is because static fields don't get reset on object
 * deletion, which means we need to take extra measures when resetting the scene.
 */
public class GameState : MonoBehaviour {
    public static GameState Instance;

    public double percentRocksToWin = 50;
    public int rounds = 3;

    public event UnitEventHandler OnGameWin;
    public event UnitEventHandler OnGameLose;
    public event UnitEventHandler OnGameStart;

    [NonSerialized] public int RocksDead = 0; //TODO increment
    [NonSerialized] public int RocksEntered = 0;
    [NonSerialized] public bool PlanningStage = true;
    [NonSerialized] public int Round = 1;
    
    public static int LatestStage => PlayerPrefs.GetInt("latestStage", 1);

    private const int FirstStageId = 1;

    void OnEnable() {
        Instance = this;
        if (SceneManager.GetActiveScene().buildIndex > LatestStage)
            PlayerPrefs.SetInt("latestStage", LatestStage + 1);
        
        //Quick dirty check to see if the menu hasn't already been loaded
        if (GameObject.Find("Planning Menu") == null)
            SceneManager.LoadScene("PlanMenu", LoadSceneMode.Additive);
    }

    public void StartPlaying() {
        Instance.PlanningStage = false;
        OnGameStart?.Invoke();
    }
    
    public void CheckWin() {
        if ((double) RocksEntered / RockSpawner.TotalSpawns * 100 >= percentRocksToWin) OnGameWin?.Invoke();
    }
    
    public void CheckLoss() {
        //lose once it's impossible to reach percent of rocks required for win
        if ((double) RocksDead / RockSpawner.TotalSpawns * 100 > 100 - percentRocksToWin) OnGameLose?.Invoke();
    }

    public static void LoadStage(string name) {
        SceneManager.LoadScene(name);
    }

    public static void LoadStage(int id) {
        SceneManager.LoadScene(id);
    }

    /** Loads the stage the player has not yet beaten. */
    public static void LoadLatestStage() {
        LoadStage(LatestStage + FirstStageId);
    }
    
    public static void RestartStage() {
        LoadStage(SceneManager.GetActiveScene().buildIndex);
    }
    
    public static void LoadNextStage() {
        LoadStage(SceneManager.GetActiveScene().buildIndex + 1);
    }
}