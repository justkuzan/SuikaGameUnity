using _Project.Scripts.Utils;
using UnityEngine;
using TMPro;
public class GameoverView : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    private void OnEnable()
    {
        GameEvents.OnGameOver += ShowGameOverView;
        UpdateScoreDisplay();
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverView;
    }

    private void ShowGameOverView()
    {
        gameOverPanel.SetActive(true);
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (Services.Score != null && currentScoreText != null)
        {
            int finalScore = Services.Score.CurrentScore;
            int bestScore = Services.Score.HighScore;
            
            currentScoreText.text = $"{finalScore}";
            highScoreText.text = $"{bestScore}";
        }
    }
    
    public void OnRestartButtonClicked()
    {
        Services.Game.RestartGame();
    }
}
