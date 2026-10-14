using UnityEngine;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerHealth>().TakeDamage(1);
            other.transform.position = new Vector3(0, 0, 0);
        }
    }
}
