using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBase : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spaceship spaceship))
        {
            _player.TakeDamageOnEnemyGone();

            spaceship.ImmediateDeath();
        }
    }
}
