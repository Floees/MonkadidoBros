using System;
using System.Diagnostics;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Attempts, Score = 0;
    public string playerName, TimeText;
    public bool stopwatchRunning = true;
    public TimeSpan time;

    private Stopwatch stopwatch = new Stopwatch();

    private void Start()
    {
        stopwatch.Start();
    }
    private void Update()
    {
        TimePassed();
    }


    private void TimePassed()
    {
        if (!stopwatchRunning)
        {
            stopwatch.Stop();
            return;
        }

        if (!stopwatch.IsRunning)
            stopwatch.Start();

        time = stopwatch.Elapsed;
        TimeText = time.ToString(@"mm\:ss");

        GameEvents.current.SecondPassed();

    }
    public void Respawn() 
    {
        Attempts++;
        GameEvents.current.Respawn();
    }
}
