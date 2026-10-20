using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public event Action onSocialScoreChanged;
    public event Action onSecondPassed;
    public event Action onRespawn;
    public event Action onGoalReached;
    public event Action onFinish;


    private void Awake()
    {
        current = this;
    }
    public void SocialScoreChanged()
    {
        onSocialScoreChanged?.Invoke();
    }
    public void SecondPassed()
    {
        onSecondPassed?.Invoke();
    }
    public void Respawn()
    {
        onRespawn?.Invoke();
    }
    public void GoalReached() 
    {
        onGoalReached?.Invoke();
    }
    public void Finish() 
    {
        onFinish?.Invoke();
    }
}
