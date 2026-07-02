using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Spawner Behavior")]
    public float movementLimitX;
    public float spawnCooldown;
    
    [Header("General Gameplay")]
    public float loseTimerLimit;
    public float gameOverLineTimerLimit;
    public float comboLeeway;
    public int comboMultiplier;
    
    [Header("Early Game Drops")]
    public int lvl1DropQuantity;
    public int lvl2DropQuantity;
    public int lvl3DropQuantity;
    
    [Header("Flower and Merge Physics")]
    public float mergeJumpForce;
    public float mergeRotationForce;
    public float dropImpulse;
}
