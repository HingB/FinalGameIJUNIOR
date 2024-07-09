using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;

    private bool _controllingIsBlocked;

    private void Update()
    {
        if (_controllingIsBlocked)
            return;

        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * (_speed * Time.deltaTime));
    }

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;   
    }

    private void OnPlayerDied()
    {
        _controllingIsBlocked = true;
    }
}
