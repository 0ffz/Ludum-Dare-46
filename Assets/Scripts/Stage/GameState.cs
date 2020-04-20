using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Rocks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * The status of the game. Follows a singleton pattern, meaning only one instance of this object should
 * ever exist. The reason we don't use static here is because static fields don't get reset on object
 * deletion, which means we need to take extra measures when resetting the scene.
 */
public class GameState : MonoBehaviour {

    [Serializable]
    public class MultiDimensionalInt {
        public GameObject[] items;
    }

    public MultiDimensionalInt[] rounds;

    public static GameState Instance;

    public double percentRocksToWin = 50;

    public event UnitEventHandler OnGameWin;
    public event UnitEventHandler OnGameLose;
    public event UnitEventHandler OnPlanComplete;
    public event UnitEventHandler OnRoundStart;

    [NonSerialized] public int RocksDead = 0; //TODO increment
    [NonSerialized] public int RocksEntered = 0;
    [NonSerialized] public bool PlanningStage = true;
    [NonSerialized] public bool Dead = false;
    [NonSerialized] public int Round = 1;

    public static int LatestStage => PlayerPrefs.GetInt("latestStage", 1);
    public int MaxRounds => rounds.Length;
    
    private const int FirstStageId = 1;

    void Awake() {
        Instance = this;
        if (SceneManager.GetActiveScene().buildIndex > LatestStage)
            PlayerPrefs.SetInt("latestStage", LatestStage + 1);
        
        if (!SceneManager.GetSceneByName("PlanMenu").isLoaded)
            SceneManager.LoadScene("PlanMenu", LoadSceneMode.Additive);
    }

    private void Start() {

        StartRound();
    }

    public void FinishPlanning() {
        Instance.PlanningStage = false;
        OnPlanComplete?.Invoke();
    }

    public void CheckWin() {
        if ((double) RocksEntered / RockSpawner.TotalSpawns * 100 >= percentRocksToWin) OnGameWin?.Invoke();
    }

    public void CheckLoss() {
        //lose once it's impossible to reach percent of rocks required for win
        if ((double) RocksDead / RockSpawner.TotalSpawns * 100 > 100 - percentRocksToWin) {
            OnGameLose?.Invoke();
            Dead = true;
        }
    }

    public void StartRound() {
        foreach (var rock in FindObjectsOfType<Rock>())
            Destroy(rock.gameObject);
        PlanningStage = true;
        RocksDead = 0;
        RocksEntered = 0;
        print("Round is starting");
        OnRoundStart?.Invoke();
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