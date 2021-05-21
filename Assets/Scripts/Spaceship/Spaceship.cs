using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth;

    public event UnityAction SpaceshipDied;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _maxHealth = _currentHealth;
    }

    public void TakeDamage(int value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
            Die();

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void RegenerateHealth(int quality)
    {
        _currentHealth += quality;

        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    public void ImmediateDeath()
    {
        Die();
    }

    private void Die()
    {
        SpaceshipDied?.Invoke();
    }
}
