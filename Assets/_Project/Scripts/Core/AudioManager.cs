using UnityEngine;
using UnityEngine.Audio;
using _Project.Scripts.Utils;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioMixer mainMixer;
	[SerializeField] private AudioSource sfxSource;
	[SerializeField] private AudioSource comboSource;
	
	[Header("Background Channels")]
	[SerializeField] private AudioSource musicSource;
	[SerializeField] private AudioSource ambienceSource;
	
	public bool IsMusicActive => PlayerPrefs.GetInt("MusicActive", 1) == 1;
	public bool IsSFXActive => PlayerPrefs.GetInt("SFXActive", 1) == 1;

	private void Awake()
	{
		Services.Audio = this;
	}
	
	private void Start()
	{
		bool musicActive = PlayerPrefs.GetInt("MusicActive", 1) == 1;
		bool sfxActive = PlayerPrefs.GetInt("SFXActive", 1) == 1;
		
		SetMusicGroupActive(musicActive);
		SetSFXGroupActive(sfxActive);
	}
	
	public void PlaySFX(AudioConfig config, float pitchOverride = -1f)
	{
		if (config == null || config.audioClip == null) return;
		sfxSource.outputAudioMixerGroup = config.audioMixerGroup;
		float finalPitch = (pitchOverride > 0) ? pitchOverride : config.pitch + Random.Range(-config.pitchRandomness, config.pitchRandomness);
		sfxSource.pitch = finalPitch;
		sfxSource.PlayOneShot(config.audioClip, config.volume);
	}
	
	public void PlayComboSFX(AudioConfig config, float pitch)
	{
		if (config == null || config.audioClip == null) return;
		comboSource.pitch = pitch;
		comboSource.PlayOneShot(config.audioClip, config.volume);
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
		
		PlayerPrefs.SetInt("MusicActive", isActive ? 1 : 0);
		PlayerPrefs.Save();
	}

	public void SetSFXGroupActive(bool isActive)
	{
		float db = isActive ? 0f : -80f;
		mainMixer.SetFloat("SFXVolume", db);
		
		PlayerPrefs.SetInt("SFXActive", isActive ? 1 : 0);
		PlayerPrefs.Save();
	}
} 
