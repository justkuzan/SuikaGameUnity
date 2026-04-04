using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    
    public GameObject gameOverScreen;

    private float loseTimer;
    private int flowersInZone;

    public void Update()
    {
        if (flowersInZone > 0)
        {
            loseTimer += Time.deltaTime;
            if (loseTimer >= settings.loseTimerLimit) gameOverScreen.SetActive(true);
        }
        if (flowersInZone <= 0) loseTimer = 0;
    }

    public void AddTime()
    {   
        flowersInZone++;
    }

    public void SubTime()
    {
        flowersInZone--;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
