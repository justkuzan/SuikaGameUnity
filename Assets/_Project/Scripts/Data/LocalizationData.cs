using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LocalizationEntry
{
    public string key;
    public string ru;
    public string en;
}

[CreateAssetMenu(fileName = "LocalizationData", menuName = "Scriptable Objects/LocalizationData")]
public class LocalizationData : ScriptableObject
{
    public List<LocalizationEntry> entries;
}
