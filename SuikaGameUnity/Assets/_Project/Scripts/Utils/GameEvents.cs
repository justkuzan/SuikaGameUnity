using System;

public static class GameEvents
{
    public static Action<bool> OnZoneStatusChanged;
    public static Action OnInputClick;
    public static Action OnFlowersCollided;
}
