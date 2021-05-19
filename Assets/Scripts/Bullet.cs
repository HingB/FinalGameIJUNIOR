using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDeath = 10;
    [SerializeField] private float _speed;

    private int _damage;

    private void Start()
    {
        DieAfterSomeTime();
    }

    public void SetDamage(int value)
    {
        if (value < 300 || value > 0)
            _damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spaceship spaceship))
            spaceship.TakeDamage(_damage);

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);
    }

    private void DieAfterSomeTime()
    {
        Destroy(gameObject, _timeBeforeDeath);
    }
}
