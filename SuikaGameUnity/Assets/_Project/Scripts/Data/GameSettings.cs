using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Spawner Behavior")]
    public float movementLimitX;
    
    [Header("General Gameplay")]
    public float loseTimerLimit;
}
