using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private GameSettings settings;

	private InputSystem_Actions _inputActions;
	private bool _isPointerOverUI;
	public float generatedX;

	private void Awake()
	{
		_inputActions = new InputSystem_Actions();
	}

	private void OnEnable() => _inputActions.Enable();
	private void OnDisable() => _inputActions.Disable();

	void Update()
	{
		Vector2 screenPos = _inputActions.UI.Point.ReadValue<Vector2>();

		Vector3 mouseWorldPosition = new Vector3(screenPos.x, screenPos.y, Mathf.Abs(mainCamera.transform.position.z));
		Vector3 worldPos = mainCamera.ScreenToWorldPoint(mouseWorldPosition);

		float xPosClamp = Mathf.Clamp(worldPos.x, -settings.movementLimitX, settings.movementLimitX);
		generatedX = xPosClamp;

		if (_inputActions.Player.Attack.WasPressedThisFrame())
		{
			_isPointerOverUI = EventSystem.current.IsPointerOverGameObject();
			if (!_isPointerOverUI)
			{
				InputPressed();
			}
		}

		if (_inputActions.Player.Attack.WasReleasedThisFrame())
		{
			if (!_isPointerOverUI)
			{
				InputClicked();
			}

			_isPointerOverUI = false;
		}
	}

	public void InputClicked()
	{
		GameEvents.OnInputClick?.Invoke();
	}

	public void InputPressed()
	{
		GameEvents.OnInputPressed?.Invoke();
	}
}