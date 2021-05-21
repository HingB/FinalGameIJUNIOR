using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooter : MonoBehaviour
{
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private int _damage;
    [SerializeField] private float _timeBetweenShots;

    private float _lastShotTime;

    private void Update()
    {
        _lastShotTime -= Time.deltaTime;

        if(_lastShotTime <= 0)
        {
            Shoot();
            _lastShotTime = _timeBetweenShots;
        }
    }

    private void Shoot()
    {
        int shootPointNumber = Random.Range(0, _shootPoints.Length);

        Instantiate(_bulletTemplate, _shootPoints[shootPointNumber].position, _shootPoints[shootPointNumber].rotation);
    }
}