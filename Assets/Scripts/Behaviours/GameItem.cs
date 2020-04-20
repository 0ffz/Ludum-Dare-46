using UnityEngine;
using UnityEngine.UIElements;

public class GameItem : MonoBehaviour {
    public bool allowInPlan;
    public bool allowInPlay;
    public static GameObject CurrentlyActive = null;

    void OnMouseUp() {
        if (CurrentlyActive == gameObject) CurrentlyActive = null;
    }
    
    void OnMouseDown() {
        if (CurrentlyActive == null) CurrentlyActive = gameObject;
    }

    public bool Allowed => (CurrentlyActive == null || CurrentlyActive == gameObject)
                           && !GameState.Instance.Dead
                           && (GameState.Instance.PlanningStage && allowInPlan ||
                               !GameState.Instance.PlanningStage && allowInPlay);
}