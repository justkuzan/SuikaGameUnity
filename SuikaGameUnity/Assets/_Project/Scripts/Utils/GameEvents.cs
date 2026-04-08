using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<bool> OnZoneStatusChanged;
    public static Action OnInputClick;
    public static Action<FlowerData, Vector3> OnFlowersCollided;
}
