using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    public GameObject[] textObjects;

    // Start is called before the first frame update

    // Update is called once per frame
    void OnEnable()
    {
            GameState.Instance.OnRoundStart += BeginText;
            GameState.Instance.OnPlanComplete += NumberText;
    }

    void BeginText() {
        if (GameState.Instance.Round == 1) {
            textObjects[0].SetActive(true);
            textObjects[1].SetActive(false);
            textObjects[2].SetActive(false);
            textObjects[4].SetActive(false);
            textObjects[3].SetActive(false);
        }
        else if (GameState.Instance.Round == 2) {
            textObjects[0].SetActive(false);
            textObjects[1].SetActive(false);
            textObjects[2].SetActive(true);
            textObjects[4].SetActive(true);

        }
        else if (GameState.Instance.Round == 3) {
            textObjects[3].SetActive(true);
        }
        else {
            textObjects[0].SetActive(false);
            textObjects[1].SetActive(false);
        }
    }

    void NumberText() {
        if (GameState.Instance.Round == 1) {
            textObjects[0].SetActive(false);
            textObjects[1].SetActive(true);
        }
        else if (GameState.Instance.Round == 2) {
            textObjects[2].SetActive(false);
            textObjects[4].SetActive(false);
        }
    }
}
