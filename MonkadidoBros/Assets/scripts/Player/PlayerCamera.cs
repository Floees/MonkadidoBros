using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera PC;
    public Transform PT;
    public float CameraHeight = 3.5f;


    private void Update()
    {
        CameraFollow();
    }

    void CameraFollow() 
    {
        PC.transform.position = new Vector3(PT.position.x, PT.position.y +CameraHeight, -10);
        PC.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (PT.position.x < 0)
        {
            PC.transform.position = new Vector3(0, PT.position.y +CameraHeight, -10);
        }
    }
}
