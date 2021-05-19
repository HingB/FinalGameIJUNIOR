using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _ySpawnPosition;
    [SerializeField] private float _minXSpawnPosition;
    [SerializeField] private float _maxXSpawnPosition;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private GameObject _template;

    private float _timeAfterLastSpawn;


    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _timeBetweenSpawn)
        {
            _timeAfterLastSpawn = 0;

            Vector2 spawnPosition = new Vector2(Random.Range(_minXSpawnPosition, _maxXSpawnPosition), _ySpawnPosition);

            GameObject enemy = Instantiate(_template, spawnPosition, Quaternion.identity);
            enemy.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}