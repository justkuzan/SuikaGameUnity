using UnityEngine;

public class LocalSaveProvider: ISaveProvider
{
    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public int LoadInt(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public void Flush()
    {
        PlayerPrefs.Save();
    }
}
