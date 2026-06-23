using UnityEngine;

public class MainMusic : MonoBehaviour
{
	[SerializeField] private AudioConfig mainTheme;
	[SerializeField] private AudioConfig ambientBackground;

	private void Start()
	{
		_Project.Scripts.Utils.Services.Audio.playMusic(mainTheme);
		_Project.Scripts.Utils.Services.Audio.playMusic(ambientBackground);
	}
}
