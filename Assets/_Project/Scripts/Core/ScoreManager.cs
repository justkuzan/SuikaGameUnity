using UnityEngine;
using _Project.Scripts.Utils;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    
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
        GameEvents.OnComboCalculated += HandleScoreWithCombo;
    }

    private void OnDisable()
    {
        GameEvents.OnComboCalculated -= HandleScoreWithCombo;
    }
    
    private void HandleScoreWithCombo(FlowerData data, int combo, Vector3 pos)
    {
        if (combo <= 2)
        {
            _currentScore += data.scoreReward;
        }
        else
        {
            _currentScore += data.scoreReward + (combo * settings.comboMultiplier);
        }
        
        GameEvents.OnScoreChanged?.Invoke(_currentScore);

        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            Services.Save.SetDirty();
        }
    }
}