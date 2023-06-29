using UnityEngine;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private TMP_Text _stopwatch;
    private double _time;
    private void Start()
    {
        _time = 0;
    }
    void Update()
    {
        _time += Time.deltaTime;
        TimeSpan _currentTime = TimeSpan.FromSeconds(_time);
        _stopwatch.text = 
            _currentTime.Minutes.ToString()+ ":" +
            _currentTime.Seconds.ToString()+ ":" +
            _currentTime.Milliseconds.ToString();
    }
}
