using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameItem : MonoBehaviour {
    public bool allowInPlan;
    public bool allowInPlay;
    public static GameObject CurrentlyActive = null;

    public void OnMouseUp() {
        if (CurrentlyActive == gameObject) CurrentlyActive = null;
    }
    
    public void OnMouseDown() {
        if (CurrentlyActive == null) CurrentlyActive = gameObject;
    }

    public bool Allowed => (CurrentlyActive == null || CurrentlyActive == gameObject)
                           && !GameState.Instance.Dead
                           && (GameState.CurrentRound.PlanningStage && allowInPlan ||
                               !GameState.CurrentRound.PlanningStage && allowInPlay);
}