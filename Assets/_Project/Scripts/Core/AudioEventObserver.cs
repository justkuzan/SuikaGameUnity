using UnityEngine;
using _Project.Scripts.Utils;

public class AudioEventObserver : MonoBehaviour
{
	[Header("UI Sounds")]
	[SerializeField] private AudioConfig clickSound;

	[Header("Gameplay Sounds")]
	[SerializeField] private AudioConfig mergeSound;
	[SerializeField] private AudioConfig spawnSound;
	[SerializeField] private AudioConfig hitSound;

	private void OnEnable()
	{
		GameEvents.OnInputClick += PlayClick;
		GameEvents.OnFlowersCollided += OnFlowerMerged;
		GameEvents.OnFlowerDropped += PlaySpawn;
		GameEvents.OnFlowerHit += PlayHit;
	}

	private void OnDisable()
	{
		GameEvents.OnInputClick -= PlayClick;
		GameEvents.OnFlowersCollided -= OnFlowerMerged;
		GameEvents.OnFlowerDropped -= PlaySpawn;
		GameEvents.OnFlowerHit -= PlayHit;
	}
	
	private void OnFlowerMerged(FlowerData d1, FlowerData d2, Vector3 pos)
	{
		Services.Audio.PlaySFX(mergeSound);
	}

	private void PlayClick() => Services.Audio.PlaySFX(clickSound);
	private void PlaySpawn() => Services.Audio.PlaySFX(spawnSound);
	private void PlayHit() => Services.Audio.PlaySFX(hitSound);
}
