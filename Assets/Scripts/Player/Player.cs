using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Spaceship
{
    [SerializeField] private float _timeBetweenRegenerate;
    [SerializeField] private int _healthOnRegenerate;
    [SerializeField] private int _damageOnEnemyGone;

    public event UnityAction Died;

    private void Start()
    {
        StartCoroutine(Regenerate());
    }

    public void TakeDamageOnEnemyGone()
    {
        TakeDamage(_damageOnEnemyGone);
    }

    private void OnDestroy()
    {
        Died?.Invoke();
        StopCoroutine(Regenerate());
    }

    private IEnumerator Regenerate()
    {
        while (true)
        {
            RegenerateHealth(_healthOnRegenerate);
            yield return new WaitForSeconds(_timeBetweenRegenerate);
        }
    }
}
