using TMPro;
using UnityEngine;

public class GUI : MonoBehaviour
{
    public TextMeshProUGUI SocialScore;
    public TextMeshProUGUI Attempts;
    public TextMeshProUGUI Time;
    public PlayerScore PlayerData;
    private void Start()
    {
        GameEvents.current.onSocialScoreChanged += UpdateSocialScore;
        GameEvents.current.onSecondPassed += UpdateTime;
        GameEvents.current.onRespawn += UpdateAttempts;
    }
    private void OnDisable()
    {
        GameEvents.current.onSocialScoreChanged -= UpdateSocialScore;
        GameEvents.current.onSecondPassed -= UpdateTime;
        GameEvents.current.onRespawn -= UpdateAttempts;
    }
    public void UpdateSocialScore()
    {
        SocialScore.text = $"+{PlayerData.Score}";
    }
    public void UpdateTime()
    {
        Time.text = PlayerData.TimeText;
    }
    private void UpdateAttempts() 
    {
        Attempts.text = "Deaths: " + PlayerData.Attempts.ToString();
    }


}
