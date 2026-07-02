using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    [Header("Toggle Image Component")]
    [SerializeField] private Image imageComponent;
    
    [Header("Icons")]
    [SerializeField] private Sprite iconOn;
    [SerializeField] private Sprite iconOff;
    
    [Header("Settings")]
    [SerializeField] private bool isOn = true;
    
    public UnityEvent<bool> OnToggleChanged;
    
    void Start()
    {
        UpdateVisual();
    }
    
    public void Initialize(bool state)
    {
        isOn = state;
        UpdateVisual();
    }
    
    public void Toggle()
    {
        isOn = !isOn;
        UpdateVisual();
        
        OnToggleChanged?.Invoke(isOn);
    }

    private void UpdateVisual()
    {
        if (imageComponent == null) return;
        
        imageComponent.sprite = isOn ? iconOn : iconOff;
    }
}
