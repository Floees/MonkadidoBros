using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI LeaderBoard;
    public TMP_InputField Input;
    public GameObject ScoreBackground;
    PlayerScore P;
    private void Start()
    {
        P = FindAnyObjectByType<PlayerScore>();
        if (LeaderBoard.text != string.Empty)
            ScoreBackground.SetActive(true); // load in scores from api

    }
    public void AgainButton() 
    {
        Destroy(P);
        SceneManager.LoadSceneAsync("MenuScene");
        SceneManager.UnloadSceneAsync("Finished");
    }
    public void SaveScore() 
    {
        if (P == null)
            return;

        Input.gameObject.SetActive(true);
    }
    public void InputGathered() 
    {
        P.playerName = Input.text;
        ScoreBackground.SetActive(true);
        LeaderBoard.text += $"{P.playerName} Score: {P.Score} Deaths: {P.Attempts} Time: {P.TimeText}\n";
        Input.gameObject.SetActive(false);
        Destroy(P);
        // save to api and refresh.
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
