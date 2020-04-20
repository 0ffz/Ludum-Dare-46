using System;
using UnityEngine;
using Random = System.Random;

public abstract class GameItem : MonoBehaviour {
    public bool allowInPlan;
    public bool allowInPlay;
    public static GameObject CurrentlyActive = null;

    private void OnEnable() {
        print("Starting!");
        transform.position += new Vector3(0, 0, (float) new Random().NextDouble() / 10f);
    }

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