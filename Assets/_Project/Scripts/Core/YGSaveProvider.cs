using UnityEngine;
using YG;

public class YGSaveProvider: ISaveProvider
{
    public void SaveInt(string key, int value)
    {
        if (key == "HighScore")
        {
            YG2.saves.HighScore = value;
        }
    }
    
    public int LoadInt(string key, int defaultValue)
    {
        if (key == "HighScore")
        {
            return YG2.saves.HighScore;
        }
        return defaultValue;
    }

    public void Flush()
    {
        // Физическая отправка данных в облако Яндекса
        YG2.SaveProgress();
    }
}