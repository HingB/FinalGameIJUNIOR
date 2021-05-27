using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Spaceship : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth;

    public event UnityAction<Spaceship> Destoyed;
    public event UnityAction<int> HealthChanged;

    private void Awake()
    {
        _maxHealth = _currentHealth;
    }

    public void TakeDamage(int value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
            Die();

        HealthChanged?.Invoke(_currentHealth);
    }

    protected void RegenerateHealth(int quantity)
    {
        _currentHealth += quantity;

        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);
    }

    public void ImmediateDeath()
    {
        Die();
    }

    private void Die()
    {
        Destoyed?.Invoke(this);
        Destroy(gameObject);
    }
}
