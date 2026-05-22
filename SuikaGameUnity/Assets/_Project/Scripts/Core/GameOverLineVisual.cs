using UnityEngine;

public class GameOverLineVisual : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    private SpriteRenderer _spriteRenderer;
    private int _flowersInWarningZone;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false; 
    }
    
    private void OnEnable()
    {
        GameEvents.OnWarningZoneStatusChanged += HandleWarningZoneChange;
    }
    
    private void OnDisable()
    {
        GameEvents.OnWarningZoneStatusChanged -= HandleWarningZoneChange;
    }

    private void HandleWarningZoneChange(bool isInZone)
    {
        if (isInZone) _flowersInWarningZone++;
        else _flowersInWarningZone--;
        
        if (_flowersInWarningZone < 0) _flowersInWarningZone = 0;

        if (_flowersInWarningZone > 0)
        {
            if (!IsInvoking(nameof(ShowLine)) && !_spriteRenderer.enabled)
            {
                Invoke(nameof(ShowLine), settings.gameOverLineTimerLimit);
            }
        }
        else
        {
            CancelInvoke(nameof(ShowLine));
            _spriteRenderer.enabled = false;
        }
    }
    
    private void ShowLine()
    {
        _spriteRenderer.enabled = true;
    }
    
}
