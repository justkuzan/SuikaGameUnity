using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    public GameManager gameManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Flower"))
        {
            gameManager.addTime();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Flower"))
        {
            gameManager.subTime();
        }
    }
}
