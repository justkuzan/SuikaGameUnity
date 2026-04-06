using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Flower"))
        {
            GameEvents.OnZoneStatusChanged?.Invoke(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Flower"))
        {
            GameEvents.OnZoneStatusChanged.Invoke(false);
        }
    }
}
