using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "Scriptable Objects/AudioConfig")]
public class AudioConfig : ScriptableObject
{
	public AudioClip audioClip;
	[Range(0f, 1f)] public float volume = 1f;
	[Range(0.5f, 1.5f)] public float pitch = 1f;
	[Range(0f, 0.3f)] public float pitchRandomness;
	public AudioMixerGroup audioMixerGroup;
}
