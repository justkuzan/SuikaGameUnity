using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameSettings settings;

    public float generatedX;
    
    void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = new Vector3(screenPos.x, screenPos.y, Mathf.Abs(mainCamera.transform.position.z));
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mouseWorldPosition);
        float xPosClamp = Mathf.Clamp(worldPos.x, -settings.movementLimitX, settings.movementLimitX);
        generatedX = xPosClamp;
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            InputClicked();
        }
    }
    
    public void InputClicked()
    {
        GameEvents.OnInputClick?.Invoke();
    }
}