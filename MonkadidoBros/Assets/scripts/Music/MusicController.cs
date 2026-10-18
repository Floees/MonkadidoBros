using System.Runtime.CompilerServices;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance;
    private void Awake()
    {
        this.InstantiateController();
    }
    void InstantiateController() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance) 
        {
            Destroy(this.gameObject);
        }
    }
    
}
