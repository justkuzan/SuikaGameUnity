using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;
using _Project.Scripts.Utils;

public class ComboView : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI comboCountText;
    [SerializeField] private TextMeshProUGUI comboMessageText;
    [SerializeField] private Image flashImage;

    private void OnEnable()
    {
        GameEvents.OnComboCalculated += ShowComboStep;
        GameEvents.OnComboEnded += ShowFinalComboMessage;
        
        comboCountText.alpha = 0;
        comboMessageText.alpha = 0;
        flashImage.color = new Color(1, 1, 1, 0);
    }

    private void OnDisable()
    {
        GameEvents.OnComboCalculated -= ShowComboStep;
        GameEvents.OnComboEnded -= ShowFinalComboMessage;
    }
    
    private void ShowComboStep(FlowerData data, int combo, Vector3 pos)
    {
        if (combo < 3) 
        {
            comboCountText.alpha = 0;
            return;
        }

        comboCountText.text = $"x{combo}";
        
        comboCountText.transform.DOKill();
        comboCountText.transform.localScale = Vector3.one;
        comboCountText.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f);
        
        comboCountText.DOKill();
        comboCountText.alpha = 1;
        comboCountText.DOFade(0, 1.5f).SetDelay(0.5f);
    }

    // 2. Показываем финальную фразу
    private void ShowFinalComboMessage(int totalCombo)
    {
        if (totalCombo < 3) return;
        
        int index = Mathf.Min(totalCombo - 2, 9); 
        string comboKey = $"combo_{index}";
        
        if (Services.Localization != null)
        {
            comboMessageText.text = Services.Localization.GetTranslation(comboKey);
        }
        
        comboMessageText.DOKill();
        comboMessageText.transform.DOKill();
        comboMessageText.alpha = 1;
        comboMessageText.transform.localPosition = Vector3.zero;
        
        comboMessageText.transform.DOLocalMoveY(50f, 1f).SetRelative();
        comboMessageText.DOFade(0, 1f).SetDelay(1f);
        
        // Вспышка экрана
        TriggerFlash();
    }

    private void TriggerFlash()
    {
        flashImage.DOKill();
        flashImage.color = new Color(1, 1, 1, 0f);
        Sequence flashSequence = DOTween.Sequence();
        flashSequence.Append(flashImage.DOFade(0.45f, 0.1f));
        flashSequence.Append(flashImage.DOFade(0f, 1f));
    }
}