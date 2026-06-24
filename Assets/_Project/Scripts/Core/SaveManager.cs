using UnityEngine;
using _Project.Scripts.Utils;

public class SaveManager : MonoBehaviour
{
    private bool _isDirty;
    private float _timer;
    
    
    private void Awake()
    {
        Services.Save = this;
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 30 && _isDirty)
        {
            SaveAll();
            _timer = 0f;
        }
    }

    public void SetDirty()
    {
        _isDirty = true;
    }

    public void SaveAll()
    {
        if (!_isDirty) return;
        if (Services.Score != null)
        {
            PlayerPrefs.SetInt("HighScore", Services.Score.HighScore);
        }
        
        // PlayerPrefs.SetInt("Coins", Services.Economy.Coins);
        
        PlayerPrefs.Save();
        _isDirty = false;
        Debug.Log("Game Saved!");
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) SaveAll();
    }
}
