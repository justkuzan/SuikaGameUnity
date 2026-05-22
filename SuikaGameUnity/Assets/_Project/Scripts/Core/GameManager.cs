using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    
    public GameObject gameOverScreen;

    private bool _isPaused = false;
    private float _loseTimer;
    private int _flowersInZone;

    private void Start()
    {
        Time.timeScale = 1f;
    }

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
        if (_flowersInZone < 0) _flowersInZone = 0;
    }
    
    public void Update()
    {
        if (_flowersInZone > 0 && !_isPaused)
        {
            _loseTimer += Time.deltaTime;
            
            if (_loseTimer >= settings.loseTimerLimit && !gameOverScreen.activeSelf)
            {
                TriggerGameOver();
            }
        }
        else
        {
            _loseTimer = 0;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _isPaused = false;
    }

    private void TriggerGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        GameEvents.OnGameOver?.Invoke();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
