using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerScore p = collision.GetComponent<PlayerScore>();
            p.stopwatchRunning = false;
            DontDestroyOnLoad(p);
            GameEvents.current.GoalReached();
        }
    }
}
