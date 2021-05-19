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
        _playersShip.OnHealthChanged += SetSliderValue;
    }

    private void OnDisable()
    {
        _playersShip.OnHealthChanged -= SetSliderValue;
    }

    public void SetSliderValue(int value)
    {
        _slider.value = value;
    }
}
