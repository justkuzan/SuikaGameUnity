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
        _highScore = Services.Save.LoadInt("HighScore", 0);
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
    
    public int CalculatePoints(FlowerData data, int combo)
    {
        if (combo < 3) 
        {
            return data.scoreReward;
        }
        return data.scoreReward + (combo * settings.comboMultiplier);
    }
    
    private void HandleScoreWithCombo(FlowerData data, int combo, Vector3 pos)
    {
        int finalPoints = CalculatePoints(data, combo);
        _currentScore += finalPoints;
        
        GameEvents.OnScoreChanged?.Invoke(_currentScore);

        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            Services.Save.SetDirty();
        }
    }
}