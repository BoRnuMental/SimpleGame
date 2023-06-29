using UnityEngine;

public class LoseSound : MonoBehaviour
{
    [SerializeField] private AudioSource _loseSound;

    private void OnEnable() => PlayerHealth.onPlayerDied += PlayLoseSound;
    private void OnDisable() => PlayerHealth.onPlayerDied -= PlayLoseSound;
    private void PlayLoseSound() => _loseSound.Play();
}
