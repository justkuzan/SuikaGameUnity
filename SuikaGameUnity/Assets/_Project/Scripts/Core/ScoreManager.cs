using TMPro;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int  _currentScore;
        
        private void OnEnable()
        {
            GameEvents.OnFlowersCollided += HandleScore;
            GameEvents.OnScoreChanged += ScoreChange;
        }

        private void OnDisable()
        {
            GameEvents.OnFlowersCollided -= HandleScore;
            GameEvents.OnScoreChanged -= ScoreChange;
        }

        private void HandleScore(FlowerData flower1, FlowerData flower2, Vector3 position)
        {
            _currentScore += flower1.scoreReward;
            GameEvents.OnScoreChanged?.Invoke(_currentScore);
        }

        private void ScoreChange(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}