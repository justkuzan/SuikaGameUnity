using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "FlowerCollection", menuName = "Scriptable Objects/FlowerCollection")]
public class FlowerCollection : ScriptableObject
{
    public List <FlowerData> flowers = new List <FlowerData>();
}
