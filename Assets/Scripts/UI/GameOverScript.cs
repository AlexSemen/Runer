using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;

        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartBurronClick);
        _exitButton.onClick.AddListener(OnExitBurronClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartBurronClick);
        _exitButton.onClick.RemoveListener(OnExitBurronClick);
    }

    private void OnDied()
    {
        DOTween.KillAll();
        _canvasGroup.alpha = 1;
        _restartButton.interactable = true;
        _exitButton.interactable = true;

        Time.timeScale = 0;
    }

    private void OnRestartBurronClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitBurronClick()
    {
        Application.Quit();
    }
}
