using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Attempts, Score = 0;
    public string playerName, TimeText;
    float currentTime;
    public bool stopwatchRunning = true;
    public TimeSpan time;

    private void Start()
    {
        currentTime = 0;
    }
    private void OnDisable()
    {
    }
    private void Update()
    {
        OnSecondPassed();
    }


    private void OnSecondPassed()
    {
        if (!stopwatchRunning)
        {
            return;
        }
        
        currentTime += Time.deltaTime;
        time = TimeSpan.FromSeconds(currentTime);
        TimeText = time.ToString(@"mm\:ss");//time.Minutes.ToString("D2") + ":" + time.Seconds.ToString("D2");
        GameEvents.current.SecondPassed();

    }
    public void Respawn() 
    {
        Attempts++;
        GameEvents.current.Respawn();
    }
}
