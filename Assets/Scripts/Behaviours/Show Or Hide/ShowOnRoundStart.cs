using UnityEngine;

public class ShowOnRoundStart : MonoBehaviour {
    void OnEnable() {
        GameState.Instance.OnRoundStart += () => {
            gameObject.SetActive(true);
        };
    }
}