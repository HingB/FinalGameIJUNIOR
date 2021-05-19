using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenChangeDirection;

    private float _timeAfterChangeDirection;
    private Vector2 _direction;

    private void Update() 
    {
        Move();

        if(_timeAfterChangeDirection >= _timeBetweenChangeDirection)
        {
            ChangeDirection();

            _timeAfterChangeDirection = 0;
        }
        _timeAfterChangeDirection += Time.deltaTime;
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
    }
}
