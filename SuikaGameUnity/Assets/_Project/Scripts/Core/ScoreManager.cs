using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int  _currentScore;
    private int _highScore;
    
    public int CurrentScore => _currentScore;
    public int HighScore => _highScore;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void OnEnable()
    {
        GameEvents.OnFlowersCollided += HandleScore;
    }

    private void OnDisable()
    {
        GameEvents.OnFlowersCollided -= HandleScore;
    }

    private void HandleScore(FlowerData flower1, FlowerData flower2, Vector3 position)
    {
        _currentScore += flower1.scoreReward;
        GameEvents.OnScoreChanged?.Invoke(_currentScore);

        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            PlayerPrefs.SetInt("HighScore", _highScore);
            
            PlayerPrefs.Save();
        }
    }
}