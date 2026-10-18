using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinished : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.onGoalReached += LoadMenu;
    }
    private void OnDisable()
    {
        GameEvents.current.onGoalReached -= LoadMenu;
    }
    public void LoadMenu() 
    {
        SceneManager.LoadSceneAsync("Finished");
        SceneManager.UnloadSceneAsync("SampleScene");
    }
}
