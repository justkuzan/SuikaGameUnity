
public interface ISaveProvider
{
    void SaveInt(string key, int value);
    int LoadInt(string key, int defaultValue);
    void Flush();
}
