using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesDestroyedQuantityIndicator : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private TMP_Text _text;

    private int _enemyDestroyedCount;

    private void OnEnable()
    {
        _spawner.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _spawner.EnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        _enemyDestroyedCount++;

        UpdateCounter();
    }

    private void UpdateCounter()
    {
        _text.text = _enemyDestroyedCount.ToString();
    }
}
