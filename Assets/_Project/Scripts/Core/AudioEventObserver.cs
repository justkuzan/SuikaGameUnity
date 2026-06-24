using UnityEngine;
using _Project.Scripts.Utils;

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
		Services.Audio.PlaySFX(clickSound);
	}

	private void PlayMerge()
	{
		Services.Audio.PlaySFX(mergeSound);
	}
}
