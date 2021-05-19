using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRestarter : MonoBehaviour
{
    [SerializeField] private Button _restartGameButton;

    private void OnEnable()
    {
        _restartGameButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _restartGameButton.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
