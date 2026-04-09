using UnityEngine;

[CreateAssetMenu(fileName = "FlowerData", menuName = "Scriptable Objects/FlowerData")]
public class FlowerData : ScriptableObject
{
    [Header("Exp and Economy")]
    public int flowerLevel;
    public int scoreReward;
    
    [Header("Physics")]
    public float colliderRadius;
    
    [Header("Drop Rate")]
    public float dropRate;
    
    [Header("Resources")]
    public Sprite flowerSprite;
    public FlowerData nextLevelData;
    
}
