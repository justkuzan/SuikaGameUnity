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
	[SerializeField] private AudioConfig comboSound;

	private void OnEnable()
	{
		GameEvents.OnInputClick += PlayClick;
		GameEvents.OnFlowerDropped += PlaySpawn;
		GameEvents.OnFlowerHit += PlayHit;
		GameEvents.OnComboCalculated += PlayCombo;
	}

	private void OnDisable()
	{
		GameEvents.OnInputClick -= PlayClick;
		GameEvents.OnFlowerDropped -= PlaySpawn;
		GameEvents.OnFlowerHit -= PlayHit;
		GameEvents.OnComboCalculated -= PlayCombo;
	}

	private void PlayClick() => Services.Audio.PlaySFX(clickSound);
	private void PlaySpawn() => Services.Audio.PlaySFX(spawnSound);
	private void PlayHit() => Services.Audio.PlaySFX(hitSound);
	
	private void PlayCombo(FlowerData data, int combo, Vector3 pos)
	{
		Services.Audio.PlaySFX(mergeSound);
		
		if (combo >= 3)
		{
			float pitchStep = 0.05f;
			float targetPitch = 1.0f + ((combo - 2) * pitchStep);
			targetPitch = Mathf.Clamp(targetPitch, 1.0f, 1.4f);
        
			Services.Audio.PlayComboSFX(comboSound, targetPitch);
		}
	}
}
