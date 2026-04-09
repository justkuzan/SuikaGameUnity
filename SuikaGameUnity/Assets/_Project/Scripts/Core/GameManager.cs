using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    
    public GameObject gameOverScreen;

    private float _loseTimer;
    private int _flowersInZone;

    private void OnEnable()
    {
        GameEvents.OnZoneStatusChanged += HandleZoneChange;
    }
    
    private void OnDisable()
    {
        GameEvents.OnZoneStatusChanged -= HandleZoneChange;
    }
    
    private void HandleZoneChange(bool isInZone)
    {
        if (isInZone) _flowersInZone++;
        else _flowersInZone--;
    }
    
    public void Update()
    {
        if (_flowersInZone > 0)
        {
            _loseTimer += Time.deltaTime;
            if (_loseTimer >= settings.loseTimerLimit) gameOverScreen.SetActive(true);
        }
        else
        {
            _loseTimer = 0;
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
