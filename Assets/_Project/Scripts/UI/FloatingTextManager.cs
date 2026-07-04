using System.Collections.Generic;
using _Project.Scripts.Utils;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FloatingTextManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameSettings settings;
    
    private Canvas _mainCanvas;
    private Queue<GameObject> _pool = new Queue<GameObject>();

    private void OnEnable()
    {
        GameEvents.OnComboCalculated += SpawnScoreText;
    }

    private void OnDisable()
    {
        GameEvents.OnComboCalculated -= SpawnScoreText;
    }

    private void SpawnScoreText(FlowerData data, int combo, Vector3 worldPos)
    {
        if (_mainCanvas == null)
        {
            _mainCanvas = GameObject.FindAnyObjectByType<Canvas>();
            if (_mainCanvas == null) return;
        }

        GameObject textObj = GetFromPool();
        RectTransform rectTransform = textObj.GetComponent<RectTransform>();
        TextMeshProUGUI tmp = textObj.GetComponent<TextMeshProUGUI>();
        
        tmp.alpha = 1;
        textObj.transform.localScale = Vector3.one;
        
        int points = Services.Score.CalculatePoints(data, combo);
        tmp.text = $"+{points}";
        
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _mainCanvas.transform as RectTransform, 
            screenPoint, 
            _mainCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main, 
            out Vector2 localPoint
        );
        rectTransform.anchoredPosition = localPoint;
        
        AnimateText(rectTransform, tmp);
    }

    private GameObject GetFromPool()
    {
        if (_pool.Count > 0)
        {
            GameObject obj = _pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        
        return Instantiate(textPrefab, _mainCanvas.transform);
    }
    
    private void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }
    
    private void AnimateText(RectTransform rect, TextMeshProUGUI tmp)
    {
        Sequence seq = DOTween.Sequence();
        
        rect.localScale = Vector3.one * 0.5f;
        seq.Join(rect.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack));
        
        float targetY = rect.anchoredPosition.y + 120f;
        seq.Join(rect.DOAnchorPosY(targetY, 1.5f).SetEase(Ease.OutCubic));
        seq.Join(tmp.DOFade(0, 0.8f).SetDelay(0.4f));
        
        seq.SetLink(rect.gameObject);
        
        seq.OnComplete(() => {
            ReturnToPool(rect.gameObject);
        });
    }
}