using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<bool> OnZoneStatusChanged;
    public static Action OnInputClick;
    public static Action<FlowerData, FlowerData, Vector3> OnFlowersCollided;
    public static Action<int> OnScoreChanged;
}
