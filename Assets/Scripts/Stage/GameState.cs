﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Events;
using Rocks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[Serializable]
public sealed class RoundInfo {
    public FreeMovable[] items;
    public int itemPicks;
    public Transform boxLocation;
    public RockSpawn[] RockSpawns => rockSpawns.Length == 0 ? GameState.Instance.rounds[0].rockSpawns : rockSpawns;
    [SerializeField] private RockSpawn[] rockSpawns;
    
    [NonSerialized] public int RocksDead = 0;
    [NonSerialized] public int RocksEntered = 0;
    [NonSerialized] public bool PlanningStage = true;
}

/**
 * The status of the game. Follows a singleton pattern, meaning only one instance of this object should
 * ever exist. The reason we don't use static here is because static fields don't get reset on object
 * deletion, which means we need to take extra measures when resetting the scene.
 */
public class GameState : MonoBehaviour {

    public static GameState Instance;
    public static RoundInfo CurrentRound => Instance.rounds[Instance.Round - 1];

    public RoundInfo[] rounds;

    public double percentRocksToWin = 50;

    public event UnitEventHandler OnGameWin;
    public event UnitEventHandler OnGameLose;
    public event UnitEventHandler OnPlanComplete;
    public event UnitEventHandler OnRoundStart;
    public GameObject[] rocks;

    [NonSerialized] public bool Dead = false;
    [NonSerialized] public int Round = 1;

    public static int LatestStage => PlayerPrefs.GetInt("latestStage", 2);
    public int MaxRounds => rounds.Length;
    public int TotalRocksToWin => (int) Mathf.Ceil((float) (percentRocksToWin / 100 * RockSpawner.TotalSpawns));
    public GameObject box;


    void Awake() {
        Instance = this;
        if (SceneManager.GetActiveScene().buildIndex > LatestStage)
            PlayerPrefs.SetInt("latestStage", SceneManager.GetActiveScene().buildIndex);
    }

    private void Start() {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene() {
        if (!SceneManager.GetSceneByName("PlanMenu").isLoaded)
            yield return SceneManager.LoadSceneAsync("PlanMenu", LoadSceneMode.Additive);
        StartRound();
    }

    public void FinishPlanning() {
        CurrentRound.PlanningStage = false;
        OnPlanComplete?.Invoke();
    }

    public event UnitEventHandler OnRockEnter;

    public void CheckWin() {
        if (CurrentRound.RocksEntered >= TotalRocksToWin) OnGameWin?.Invoke();
        OnRockEnter?.Invoke();
    }

    public event UnitEventHandler OnRockDie;

    public void CheckLoss() {
        //lose once it's impossible to reach percent of rocks required for win
        if (RockSpawner.TotalSpawns - CurrentRound.RocksDead < TotalRocksToWin) {
            OnGameLose?.Invoke();
            Dead = true;
        }

        OnRockDie?.Invoke();
    }

    public void StartRound() {
        foreach (var rock in FindObjectsOfType<Rock>())
            Destroy(rock.gameObject);
        box.transform.DOMove(CurrentRound.boxLocation.position, 1);
        print("invoking OnRoundStart");
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
        LoadStage(LatestStage);
    }

    public static void RestartStage() {
        LoadStage(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadNextStage() {
        LoadStage(SceneManager.GetActiveScene().buildIndex + 1);
    }
}