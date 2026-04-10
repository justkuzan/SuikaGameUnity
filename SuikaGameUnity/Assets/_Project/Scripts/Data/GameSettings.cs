using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Spawner Behavior")]
    public float movementLimitX;
    
    [Header("General Gameplay")]
    public float spawnCooldown;
    public float loseTimerLimit;
    
    [Header("Early Game Drops")]
    public int lvl1DropQuantity;
    public int lvl2DropQuantity;
    public int lvl3DropQuantity;
    
    [Header("Flower and Merge Physics")]
    public float mergeJumpForce;
    public float mergeRotationForce;
}
