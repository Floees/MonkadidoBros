using Unity.VisualScripting;
using UnityEngine;

public class BonusPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerScore>().Score += 1000;
            GameEvents.current.SocialScoreChanged();
            Destroy(this.GameObject());
        }
    }
}
