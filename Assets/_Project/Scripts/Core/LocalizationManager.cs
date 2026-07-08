using UnityEngine;
using System.Linq;
using YG;
using _Project.Scripts.Utils;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private LocalizationData data;
    
    private void Awake()
    {
        Services.Localization = this;
    }
    
    public string GetTranslation(string key)
    {
        var entry = data.entries.FirstOrDefault(e => e.key == key);
        
        if (entry.key == null) return $"MISSING: {key}";
        
        return YG2.lang == "ru" ? entry.ru : entry.en;
    }
}
