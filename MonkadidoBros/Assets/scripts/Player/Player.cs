using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.onFinish += RemoveCamera;
    }
    private void OnDisable()
    {
        GameEvents.current.onFinish -= RemoveCamera;
    }

    private void RemoveCamera() 
    {
        Camera pc = this.GetComponentInChildren<Camera>();
        AudioListener listener = pc.GetComponent<AudioListener>();
        Destroy(pc);
        Destroy(listener);
    }
}
