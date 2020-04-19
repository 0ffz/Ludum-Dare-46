using UnityEngine;

public class GameItem: MonoBehaviour {
    public bool allowInPlan;
    public bool allowInPlay;

    public bool Allowed => !GameState.Instance.Dead && (GameState.Instance.PlanningStage && allowInPlan || !GameState.Instance.PlanningStage && allowInPlay);
}