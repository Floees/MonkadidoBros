using System;
using Unity.VisualScripting;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public GameObject Triggered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float currenttime = Time.time;
        TimeSpan time = TimeSpan.FromSeconds(currenttime);

        if (time.TotalSeconds > 1)
        Triggered.SetActive(true);
        Destroy(this);
    }
}
