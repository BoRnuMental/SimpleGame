using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private CharacterAnimations _animations;

    private int _health;
    private int _maxHealth = 3;

    public static Action onHealthChanged;
    public static Action onPlayerDied;

    private void OnEnable()
    {
        DealDamage.onPlayerDamaged += TakeDamage;
    }
    private void OnDisable()
    {
        DealDamage.onPlayerDamaged -= TakeDamage;
    }
    void Start()
    {
        _animations = GetComponentInChildren<CharacterAnimations>();
        _health = _maxHealth;
    }
    void TakeDamage()
    {
        if (_health <= 0) return;
        _health -= 1;
        onHealthChanged?.Invoke();
        _animations.Hit();
        if (_health <= 0) Destroy(gameObject);
    }
    private void OnDestroy()
    {
        onPlayerDied?.Invoke();
    }
}
