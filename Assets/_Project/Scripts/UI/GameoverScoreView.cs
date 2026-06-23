using System;
using UnityEngine;
using TMPro;
public class GameoverScoreView : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        if (scoreManager != null && currentScoreText != null)
        {
            int finalScore = scoreManager.CurrentScore;
            int bestScore = scoreManager.HighScore;
            
            currentScoreText.text = $"{finalScore}";
            highScoreText.text = $"{bestScore}";
        }
    }
}
