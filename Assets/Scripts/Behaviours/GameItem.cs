using System;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class GameItem : MonoBehaviour {
    public bool allowInPlan;
    public bool allowInPlay;
    public static GameObject CurrentlyActive = null;
    public bool lockOnPlanComplete = false;
    private bool _locked = false;

    private void Start() {
        if (lockOnPlanComplete)
            GameState.Instance.OnPlanComplete += () => _locked = true;
    }

    public void OnMouseUp() {
        if (CurrentlyActive == gameObject) CurrentlyActive = null;
    }

    public void OnMouseDown() {
        if (CurrentlyActive == null) CurrentlyActive = gameObject;
    }

    public bool Allowed => !_locked
                           && (CurrentlyActive == null || CurrentlyActive == gameObject)
                           && !GameState.Instance.Dead
                           && (GameState.CurrentRound.PlanningStage && allowInPlan ||
                               !GameState.CurrentRound.PlanningStage && allowInPlay);
}