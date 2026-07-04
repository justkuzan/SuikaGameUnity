using UnityEngine;
using _Project.Scripts.Utils;

public class SaveManager : MonoBehaviour
{
    private ISaveProvider _saveProvider;
    private bool _isDirty;
    private float _timer;
    
    private void Awake()
    {
        Services.Save = this;
        _saveProvider = new LocalSaveProvider();
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
            _saveProvider.SaveInt("HighScore", Services.Score.HighScore);
        }
        
        // _saveProvider.SaveInt("Coins", Services.Economy.Coins);

        _saveProvider.Flush();
        _isDirty = false;
        Debug.Log("Game Saved!");
    }
    
    public int LoadInt(string key, int defaultValue = 0)
    {
        return _saveProvider.LoadInt(key, defaultValue);
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) SaveAll();
    }
}
