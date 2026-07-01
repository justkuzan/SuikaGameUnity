using UnityEngine;
using _Project.Scripts.Utils;

public class MainMusic : MonoBehaviour
{
	[SerializeField] private AudioConfig mainTheme;
	[SerializeField] private AudioConfig ambientBackground;

	private void Start() {
		Services.Audio.PlayBGM(mainTheme);
		Services.Audio.PlayAmbience(ambientBackground);
	}	
}
