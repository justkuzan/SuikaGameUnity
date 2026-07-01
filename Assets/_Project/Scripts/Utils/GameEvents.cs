using System;
using UnityEngine;

public static class GameEvents
{
    //input
    public static Action OnInputClick;
    public static Action OnInputPressed;
    
    //game rules
    public static Action OnGameOver;
    public static Action<bool> OnZoneStatusChanged;
    public static Action<bool> OnWarningZoneStatusChanged;
    
    //gameplay
    public static Action<FlowerData, FlowerData, Vector3> OnFlowersCollided;
    public static Action<int> OnScoreChanged;
    public static Action OnFlowerDropped;
    public static Action OnFlowerHit;
}
