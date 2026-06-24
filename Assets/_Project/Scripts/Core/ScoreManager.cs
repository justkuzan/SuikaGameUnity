using UnityEngine;
using _Project.Scripts.Utils;

public class ScoreManager : MonoBehaviour
{
    private int  _currentScore;
    private int _highScore;
    
    public int CurrentScore => _currentScore;
    public int HighScore => _highScore;

    private void Awake()
    {
        Services.Score = this;
    }
    
    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        GameEvents.OnScoreChanged?.Invoke(_currentScore);
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
            Services.Save.SetDirty();
        }
    }
}