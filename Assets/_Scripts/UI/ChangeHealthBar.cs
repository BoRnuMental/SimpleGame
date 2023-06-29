using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthBar : MonoBehaviour
{
    private int _healthCount = 3;

    [SerializeField] private Image[] _healths;  
    private void OnEnable()
    {
        PlayerHealth.onHealthChanged += ChangeHealthColor;
    }
    private void OnDisable()
    {
        PlayerHealth.onHealthChanged -= ChangeHealthColor;
    }

    private void ChangeHealthColor()
    {
        _healths[_healthCount - 1].color = Color.black;
        if (_healthCount < 0) return;
        _healthCount--; 
    }
}
