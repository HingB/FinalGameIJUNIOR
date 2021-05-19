using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _timeBetweenRegenerate;
    [SerializeField] private int _healthOnRegenerate;
    [SerializeField] private int _damageOnEnemyGone;
    [SerializeField] private Spaceship _spaceship;
    [SerializeField] private EnemiesDestroyedQuantityIndicator _destoyedEnemiesIndicator;

    private int _enemysDestroyed;

    public event UnityAction OnDie;

    private void Start()
    {
        ShowEnemyDiedCount();

        StartCoroutine(Regenerate());
    }

    private void OnEnable()
    {
        _spaceship.OnSpaceshipDie += OnPlayerDie;
    }

    private void OnDisable()
    {
        _spaceship.OnSpaceshipDie -= OnPlayerDie;
    }

    public void TakeDamageOnEnemyGone()
    {
        _spaceship.TakeDamage(_damageOnEnemyGone);
    }

    private void OnPlayerDie()
    {
        OnDie?.Invoke();
        StopCoroutine(Regenerate());
        Destroy(gameObject);
    }

    public void OnEnemyKilled()
    {
        _enemysDestroyed++;

        ShowEnemyDiedCount();
    }

    private void ShowEnemyDiedCount()
    {
        _destoyedEnemiesIndicator.SetNewEnemiesDestoedCount(_enemysDestroyed);
    }


    private IEnumerator Regenerate()
    {
        while (true)
        {
            _spaceship.RegenerateHealth(_healthOnRegenerate);
            yield return new WaitForSeconds(_timeBetweenRegenerate);
        }
    }
}
