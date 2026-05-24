using UnityEngine;

public class MainMusic : MonoBehaviour
{
	[SerializeField] private AudioConfig mainTheme;
	[SerializeField] private AudioConfig ambientBackground;

	private void Start()
	{
		AudioManager.Instance.playMusic(mainTheme);
		AudioManager.Instance.playMusic(ambientBackground);
	}
}
