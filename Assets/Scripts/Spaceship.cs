using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private int _health;
    private int _maxHealth;

    public event UnityAction OnSpaceshipDie;
    public event UnityAction<int> OnHealthChanged;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health <= 0)
            Die();

        OnHealthChanged?.Invoke(_health);
    }

    public void RegenerateHealth(int quality)
    {
        _health += quality;

        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }

    public void ImmediateDeath()
    {
        Die();
    }

    private void Die()
    {
        OnSpaceshipDie?.Invoke();
    }
}
