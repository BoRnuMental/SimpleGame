using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    [SerializeField] private AudioSource _hitSound;
    private void OnEnable() => DealDamage.onPlayerDamaged += PlayHitSound;
    private void OnDisable() => DealDamage.onPlayerDamaged -= PlayHitSound;
    private void PlayHitSound() => _hitSound.Play();

}
