using System;
using UnityEngine;
using TMPro;
public class GameoverScoreView : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private TextMeshProUGUI currentScoreText;

    private void OnEnable()
    {
        if (scoreManager != null && currentScoreText != null)
        {
            int finalScore = scoreManager.CurrentScore;
            currentScoreText.text = $"{finalScore}";
        }
    }
}
