using System;
using Events;
using UnityEngine;

public class PlanningMenu : MonoBehaviour {
    public void StartPlaying() {
        GameState.Instance.FinishPlanning();
    }
}