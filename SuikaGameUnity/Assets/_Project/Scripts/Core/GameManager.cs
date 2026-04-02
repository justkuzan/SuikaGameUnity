using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    private float loseTimer;
    private int flowersInZone;

    public void Update()
    {
        if (flowersInZone > 0)
        {
            loseTimer += Time.deltaTime;
            if (loseTimer >= 3f) gameOverScreen.SetActive(true);
        }
        if (flowersInZone <= 0) loseTimer = 0;
    }

    public void addTime()
    {   
        flowersInZone++;
    }

    public void subTime()
    {
        flowersInZone--;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
