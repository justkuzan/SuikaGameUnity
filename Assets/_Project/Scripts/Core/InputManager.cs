using UnityEngine;
using UnityEngine.EventSystems;
using _Project.Scripts.Utils;

public class InputManager : MonoBehaviour
{
	[SerializeField] private GameSettings settings;
	
	private Camera _camera;
	private InputSystem_Actions _inputActions;
	private bool _isPointerOverUI;
	public float generatedX;

	private Camera MainCamera
	{
		get
		{
			if (_camera == null) _camera = Camera.main;
			return _camera;
		}
	}

	private void Awake()
	{
		Services.Input = this;
		_inputActions = new InputSystem_Actions();
	}

	private void OnEnable() => _inputActions.Enable();
	private void OnDisable() => _inputActions.Disable();

	void Update()
	{
		var camera = MainCamera;
		if (camera == null) return;
		
		Vector2 screenPos = _inputActions.UI.Point.ReadValue<Vector2>();
		Vector3 mouseWorldPosition = new Vector3(screenPos.x, screenPos.y, Mathf.Abs(camera.transform.position.z));
		Vector3 worldPos = camera.ScreenToWorldPoint(mouseWorldPosition);

		float xPosClamp = Mathf.Clamp(worldPos.x, -settings.movementLimitX, settings.movementLimitX);
		generatedX = xPosClamp;

		if (_inputActions.Player.Attack.WasPressedThisFrame())
		{
			_isPointerOverUI = EventSystem.current.IsPointerOverGameObject();
			if (!_isPointerOverUI)InputPressed();
		}

		if (_inputActions.Player.Attack.WasReleasedThisFrame())
		{
			if (!_isPointerOverUI) InputClicked();
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