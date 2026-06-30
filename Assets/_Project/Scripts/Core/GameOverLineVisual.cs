using UnityEngine;
using DG.Tweening;

public class GameOverLineVisual : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    private SpriteRenderer _spriteRenderer;
    private int _flowersInWarningZone;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Color c = _spriteRenderer.color;
        _spriteRenderer.color = new Color(c.r, c.g, c.b, 0);
        _spriteRenderer.enabled = true;
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

        float targetAlpha = (_flowersInWarningZone > 0) ? 1f : 0f;
        float delay = (targetAlpha > 0) ? settings.gameOverLineTimerLimit : 0f;
        _spriteRenderer.DOKill();
        _spriteRenderer.DOFade(targetAlpha, 0.5f).SetDelay(delay);
    }
}