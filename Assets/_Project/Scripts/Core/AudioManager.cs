using UnityEngine;
using UnityEngine.Audio;
using _Project.Scripts.Utils;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioMixer mainMixer;
	[SerializeField] private AudioSource sfxSource;
	
	[Header("Background Channels")]
	[SerializeField] private AudioSource musicSource;
	[SerializeField] private AudioSource ambienceSource;

	private void Awake()
	{
		Services.Audio = this;
	}

	public void PlaySFX(AudioConfig config)
	{
		if (config == null || config.audioClip == null) return;
		sfxSource.outputAudioMixerGroup = config.audioMixerGroup;
		sfxSource.pitch = config.pitch + Random.Range(-config.pitchRandomness, config.pitchRandomness);
		sfxSource.PlayOneShot(config.audioClip, config.volume);
	}

	public void PlayBGM(AudioConfig config)
	{
		PlayLoopingTrack(musicSource, config);
	}
	
	public void PlayAmbience(AudioConfig config)
	{
		PlayLoopingTrack(ambienceSource, config);
	}
	
	private void PlayLoopingTrack(AudioSource source, AudioConfig config)
	{
		if (config == null || config.audioClip == null) return;
		
		source.volume = config.volume;
		source.outputAudioMixerGroup = config.audioMixerGroup;
		
		if (source.clip == config.audioClip && source.isPlaying) return;
		source.clip = config.audioClip;
	
		source.loop = true;
		source.Play();
	}
	
	public void SetMusicGroupActive(bool isActive)
	{
		float db = isActive ? 0f : -80f;
		mainMixer.SetFloat("MusicVolume", db);
	}

	public void SetSFXGroupActive(bool isActive)
	{
		float db = isActive ? 0f : -80f;
		mainMixer.SetFloat("SFXVolume", db);
	}
}
