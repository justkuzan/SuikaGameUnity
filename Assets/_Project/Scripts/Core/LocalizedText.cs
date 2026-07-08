using UnityEngine;
using TMPro;
using _Project.Scripts.Utils;
using YG;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string key; // Сюда в инспекторе впишем, например, ui_score
    private TextMeshProUGUI _textElement;

    private void Awake()
    {
        _textElement = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        YG2.onSwitchLang += UpdateText;
        
        UpdateText(YG2.lang);
    }

    private void OnDisable()
    {
        YG2.onSwitchLang -= UpdateText;
    }
    
    private void UpdateText(string lang)
    {
        if (Services.Localization != null && _textElement != null)
        {
            _textElement.text = Services.Localization.GetTranslation(key);
        }
    }
    
    public void SetKey(string newKey)
    {
        key = newKey;
        UpdateText(YG2.lang);
    }
}