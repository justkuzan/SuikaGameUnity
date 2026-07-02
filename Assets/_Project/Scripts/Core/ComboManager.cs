using UnityEngine;
using _Project.Scripts.Utils;

public class ComboManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;

    public int comboCount;
    
    private float _lastComboTime = -1f;
    
    private void Awake()
    {
        Services.Combo = this;
    }
    
    private void OnEnable()
    {
        GameEvents.OnFlowersCollided += HandleCombo;
    }

    private void OnDisable()
    {
        GameEvents.OnFlowersCollided -= HandleCombo;
    }

    public void HandleCombo(FlowerData currentData, FlowerData nextData, Vector3 flowerPosition)
    {
        float now = Time.time;
        float timeSinceLastMerge = now - _lastComboTime;

        if (timeSinceLastMerge <= settings.comboLeeway)
        {
            comboCount++;
        }
        else
        {
            comboCount = 0;
        }

        _lastComboTime = now;
        
        // GameEvents.OnComboChanged?.Invoke(comboCount);
        GameEvents.OnComboCalculated?.Invoke(currentData, comboCount, flowerPosition);
    }
}
