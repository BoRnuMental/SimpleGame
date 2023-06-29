using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    enum Direction
    {
        Left, Right
    }

    [SerializeField] private Direction _direction = Direction.Right;
    private float _speed;
    private Vector3 _attackDirection;
    private void Start()
    {
        _speed = Random.Range(5f, 10f);
        if (_direction == Direction.Right)
        {
            _attackDirection = new Vector3(1, 0, 0);
        }
        else
        {
            _attackDirection = new Vector3(-1, 0, 0);
        }
    }
    void Update()
    {
        transform.position += _attackDirection * _speed * Time.deltaTime;
    }
}
