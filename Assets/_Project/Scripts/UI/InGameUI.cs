using UnityEngine;
using _Project.Scripts.Utils;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private CustomToggle musicToggle;
    [SerializeField] private CustomToggle sfxToggle;
    
    private void Start()
    {
        if (Services.Audio != null)
        {
            musicToggle.Initialize(Services.Audio.IsMusicActive);
            sfxToggle.Initialize(Services.Audio.IsSFXActive);
        }
    }
    
    public void ToggleMusic(bool isOn)
    {
        if (Services.Audio != null)
        {
            Services.Audio.SetMusicGroupActive(isOn);
        }
    }
    
    public void ToggleSFX(bool isOn)
    {
        if (Services.Audio != null)
        {
            Services.Audio.SetSFXGroupActive(isOn);
        }
    }
}
