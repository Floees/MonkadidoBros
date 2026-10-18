using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public event Action onSocialScoreChanged;
    public event Action onSecondPassed;
    public event Action onRespawn;


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
}
