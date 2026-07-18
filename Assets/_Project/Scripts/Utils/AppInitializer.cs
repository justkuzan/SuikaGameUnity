using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Utils
{
    public static class AppInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var globalContext = Resources.Load<GameObject>("[GlobalContext]");
            if (globalContext == null)
            {
                Debug.LogError("Could not find the [GlobalContext] prefab in the Resources folder");
                return;
            }
            
            var instance = GameObject.Instantiate(globalContext);
            GameObject.DontDestroyOnLoad(instance);

            Debug.Log("Global systems initialized");
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void LoadFirstLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}