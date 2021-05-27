using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _ySpawnPosition;
    [SerializeField] private float _minXSpawnPosition;
    [SerializeField] private float _maxXSpawnPosition;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private GameObject _template;

    private float _timeAfterLastSpawn;
    private List<Spaceship> _enemys = new List<Spaceship>();

    public event UnityAction EnemyKilled;

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _timeBetweenSpawn)
        {
            _timeAfterLastSpawn = 0;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_minXSpawnPosition, _maxXSpawnPosition), _ySpawnPosition);

        Enemy enemy = Instantiate(_template, spawnPosition, Quaternion.identity).GetComponent<Enemy>();
        enemy.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);

        enemy.Destoyed += OnEnemyDied;
        _enemys.Add(enemy);
    }

    private void OnEnemyDied(Spaceship spaceship)
    {
        spaceship.Destoyed -= OnEnemyDied;
        _enemys.Remove(spaceship);
        EnemyKilled?.Invoke();
    }
}