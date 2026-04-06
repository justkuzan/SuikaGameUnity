using System;

public static class GameEvents
{
    public static Action<bool> OnZoneStatusChanged;
    
    // public static System.Action<int> OnFlowerAddedToZone; // int — сколько цветов в зоне
    // public static System.Action OnGameOver;
    // public static System.Action<FlowerData, Vector3> OnMerge; // Какой цветок и где создаем
    
    // OnFlowerDropped: Спавнер сообщает, что цветок улетел (нужно обновить очередь в SpawnManager).
    // OnFlowersCollided: Цветок сообщает, что ударился о другой такой же цветок (нужно вызвать MergeManager).
    // OnScoreChanged: Менеджер очков сообщает, что счет вырос (нужно обновить текст в UI).
    // OnGameOver: Игра сообщает, что всё закончилось (нужно показать экран конца игры).
}
