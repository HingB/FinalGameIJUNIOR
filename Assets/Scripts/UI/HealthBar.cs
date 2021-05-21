using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Spaceship _playersShip;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _playersShip.HealthChanged += OnValueChanged;
        _slider.maxValue = 1;
    }

    private void OnDisable()
    {
        _playersShip.HealthChanged -= OnValueChanged;
    }

    public void OnValueChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}
