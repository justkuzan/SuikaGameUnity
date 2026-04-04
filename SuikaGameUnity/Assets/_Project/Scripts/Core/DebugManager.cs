using UnityEngine;
using UnityEngine.InputSystem;

public class DebugManager : MonoBehaviour
{
    public GameObject debugPanel;
    
    void Update()
    {
        if (Keyboard.current.backquoteKey.wasPressedThisFrame)
        {
            debugPanel.SetActive(!debugPanel.activeSelf);
        }
    }
}
