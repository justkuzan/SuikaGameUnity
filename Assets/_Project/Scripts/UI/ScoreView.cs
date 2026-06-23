using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void OnEnable()
    {
        GameEvents.OnScoreChanged += ScoreChange;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreChanged -= ScoreChange;
    }
    
    private void ScoreChange(int score)
    {
        _scoreText.text = score.ToString();
    }
}
