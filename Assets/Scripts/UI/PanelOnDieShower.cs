using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOnDieShower : MonoBehaviour
{
    [SerializeField] GameObject _restartPanel;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _restartPanel.SetActive(true);
    }
}
