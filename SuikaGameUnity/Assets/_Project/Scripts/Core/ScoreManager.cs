using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int  _currentScore;
    
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
    }
}