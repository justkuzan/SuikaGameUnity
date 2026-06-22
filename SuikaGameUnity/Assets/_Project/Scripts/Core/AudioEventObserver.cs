using UnityEngine;

public class AudioEventObserver : MonoBehaviour
{
	[Header("UI Sounds")]
	[SerializeField] private AudioConfig clickSound;

	[Header("Gameplay Sounds")]
	[SerializeField] private AudioConfig mergeSound;
	[SerializeField] private AudioConfig spawnSound;

	private void OnEnable()
	{
		// Подписываемся на твои экшены из GameEvents
		GameEvents.OnInputClick += PlayClick;
		// Сюда же дописываешь остальные события, например:
		// GameEvents.OnFlowerMerged += PlayMerge;
	}

	private void OnDisable()
	{
		GameEvents.OnInputClick -= PlayClick;
	}

	private void PlayClick()
	{
		AudioManager.Instance.PlaySFX(clickSound);
	}

	private void PlayMerge()
	{
		AudioManager.Instance.PlaySFX(mergeSound);
	}
}
