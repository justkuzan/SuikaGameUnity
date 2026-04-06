using UnityEngine;

[CreateAssetMenu(fileName = "FlowerData", menuName = "Scriptable Objects/FlowerData")]
public class FlowerData : ScriptableObject
{
    public int flowerLevel;
    public Sprite flowerSprite;
    public float colliderRadius;
    public FlowerData nextLevelData;
    public int scoreReward;
}
