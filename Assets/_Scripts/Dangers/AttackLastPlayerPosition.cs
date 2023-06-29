using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLastPlayerPosition : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;
    private Vector3 _targetPosition;
    void Start()
    {
        _targetPosition = PlayerMovement.PlayerPosition;
        _direction = _targetPosition - transform.position;
        _speed = Random.Range(5f, 10f);       
    }
    void Update()
    {
        transform.position += _direction.normalized * _speed * Time.deltaTime;
    }
}
