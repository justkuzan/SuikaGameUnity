using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; }

	[SerializeField] private AudioConfig backgroundMusic;

	[SerializeField] private AudioMixer mainMixer;
	[SerializeField] private AudioSource musicSource;
	[SerializeField] private AudioSource sfxSource;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		Instance.playMusic(backgroundMusic);
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
		if (musicSource.clip == config.audioClip && musicSource.isPlaying) return;
		musicSource.outputAudioMixerGroup = config.audioMixerGroup;
		musicSource.clip = config.audioClip;
		musicSource.volume = config.volume;
		musicSource.pitch = 1;
		musicSource.loop = true;

		musicSource.Play();
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
