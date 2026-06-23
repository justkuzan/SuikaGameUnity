using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioMixer mainMixer;
	[SerializeField] private AudioSource sfxSource;
	[SerializeField] private AudioSource[] musicSource;

	private void Awake()
	{
		_Project.Scripts.Utils.Services.Audio = this;
	}

	public void PlaySFX(AudioConfig config)
	{
		if (config == null || config.audioClip == null) return;
		sfxSource.outputAudioMixerGroup = config.audioMixerGroup;
		sfxSource.pitch = config.pitch + Random.Range(-config.pitchRandomness, config.pitchRandomness);
		sfxSource.PlayOneShot(config.audioClip, config.volume);
	}

	public void playMusic(AudioConfig config)
	{
		if (config == null || config.audioClip == null) return;
		foreach (var source in musicSource)
		{
			if (source.clip == config.audioClip && source.isPlaying) return;
		}
		foreach (var source in musicSource)
		{
			if (!source.isPlaying)
			{
				source.outputAudioMixerGroup = config.audioMixerGroup;
				source.clip = config.audioClip;
				source.volume = config.volume;
				source.pitch = 1f;
				source.loop = true;
				source.Play();
				return;
			}
		}
	}

	public void SetMusicActive(bool isActive)
	{
		float volume = isActive ? 0f : -80f;
		mainMixer.SetFloat("MusicVolume", volume);
	}

	public void SetSFXActive(bool isActive)
	{
		float volume = isActive ? 0f : -80f;
		mainMixer.SetFloat("SFXVolume", volume);
	}
}
