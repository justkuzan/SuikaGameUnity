using _Project.Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameSettings settings;
	
	private float _loseTimer;
	private int _flowersInZone;

	public enum GameState
	{
		Menu,
		Play,
		Pause,
		Gameover,
	}

	private GameState _currentState;

	public GameState SetState(GameState newState)
	{
		switch (newState)
		{
			case GameState.Menu:
				break;
			case GameState.Play:
				Time.timeScale = 1f;
				_flowersInZone = 0;
				_loseTimer = 0;
				break;
			case GameState.Pause:
				Time.timeScale = 0f;
				break;
			case GameState.Gameover:
				Time.timeScale = 0f;
				GameEvents.OnGameOver?.Invoke();
				break;
		}
		_currentState = newState;
		return newState;
	}

	public void Awake()
	{
		Services.Game = this;
	}

	public void Start()
	{
		SetState(GameState.Play);
	}

	public void Update()
	{
		if (_currentState == GameState.Play && _flowersInZone > 0)
		{
			_loseTimer += Time.deltaTime;
			if (_loseTimer >= settings.loseTimerLimit)
			{
				SetState(GameState.Gameover);
			}
		}
		else
		{
			_loseTimer = 0;
		}
	}

	private void OnEnable()
	{
		GameEvents.OnZoneStatusChanged += HandleZoneChange;
	}

	private void OnDisable()
	{
		GameEvents.OnZoneStatusChanged -= HandleZoneChange;
	}

	private void HandleZoneChange(bool isInZone)
	{
		if (isInZone) _flowersInZone++;
		else _flowersInZone--;
		if (_flowersInZone < 0) _flowersInZone = 0;
	}

	private void OnGameOver()
	{
		SetState(GameState.Gameover);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
