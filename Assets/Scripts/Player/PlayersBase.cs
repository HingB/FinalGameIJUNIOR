using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spaceship spaceship))
        {
            Player player = FindObjectOfType<Player>();

            if(player != null)
                player.TakeDamageOnEnemyGone();

            spaceship.ImmediateDeath();
        }
    }
}
