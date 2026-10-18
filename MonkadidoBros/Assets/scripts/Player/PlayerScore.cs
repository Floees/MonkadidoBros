using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Attempts, Score = 0;
    public string playerName, TimeText;
    float currentTime;
    bool stopwatchRunning = true;

    private void Start()
    {
        currentTime = 0;
        GameEvents.current.onSocialScoreChanged += OnSocialScoreGained;
        GameEvents.current.onRespawn += OnRespawn;
    }
    private void OnDisable()
    {
        GameEvents.current.onSocialScoreChanged -= OnSocialScoreGained;
        GameEvents.current.onRespawn -= OnRespawn;
    }
    private void Update()
    {
        OnSecondPassed();
    }


    private void OnSocialScoreGained() 
    {
        Score = +1000;
    }
    private void OnSecondPassed()
    {
        if (!stopwatchRunning)
        {
            return;
        }
        
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        TimeText = time.Minutes.ToString("D2") + ":" + time.Seconds.ToString("D2");
        GameEvents.current.SecondPassed();

    }
    private void OnRespawn() 
    {
        Attempts++;
    }
}
