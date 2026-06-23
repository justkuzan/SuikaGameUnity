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
		GameEvents.OnInputClick += PlayClick;
	}

	private void OnDisable()
	{
		GameEvents.OnInputClick -= PlayClick;
	}

	private void PlayClick()
	{
		_Project.Scripts.Utils.Services.Audio.PlaySFX(clickSound);
	}

	private void PlayMerge()
	{
		_Project.Scripts.Utils.Services.Audio.PlaySFX(mergeSound);
	}
}
