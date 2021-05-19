using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Spaceship _spaceship;

    private Player _player;

    private void OnEnable()
    {
        _spaceship.OnSpaceshipDie += OnDie;
    }

    private void OnDisable()
    {
        _spaceship.OnSpaceshipDie -= OnDie;
    }

    private void OnDie()
    {
        _player = FindObjectOfType<Player>();

        if(_player != null)
            _player.OnEnemyKilled();


        Destroy(gameObject);
    }
}
