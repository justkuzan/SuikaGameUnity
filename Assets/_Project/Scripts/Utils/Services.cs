using UnityEngine;

namespace _Project.Scripts.Utils
{
    public static class Services
    {
        public static AudioManager Audio { get; set; }
        public static InputManager Input { get; set; }
        public static ScoreManager Score { get; set; }
        public static SaveManager Save { get; set; }
        public static GameManager Game { get; set; }
        public static SpawnManager Spawner { get; set; }
        public static DebugManager Debugger { get; set; }
    }
}