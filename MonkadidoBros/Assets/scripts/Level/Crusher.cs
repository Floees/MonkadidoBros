using Unity.VisualScripting;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public GameObject Triggered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Triggered.SetActive(true);
    }
}
