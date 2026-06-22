using UnityEngine;
using UnityEngine.SceneManagement;

public class AppBootstrap : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Main");
    }
}
