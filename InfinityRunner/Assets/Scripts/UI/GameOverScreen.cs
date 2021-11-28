using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Player _player;
    [SerializeField] private Score _score;

    private CanvasGroup _gameOverGroup;

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();

        ChangeVisibilityGameOver(false);
    }

    private void OnEnable()
    {
        _player.Died += OnDied;       
        
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;        
    }

    private void OnDied()
    {
        ChangeVisibilityGameOver(true);
        _pauseMenu.SetActive(false);

        Time.timeScale = 0;
        TopResults.Instance.AddResult(_score.CurrentScore);
    }

    private void ChangeVisibilityGameOver(bool isNeedToShow)
    {
        if (isNeedToShow == true)
        {
            _gameOverGroup.alpha = 1;
        }
        else
        {
            _gameOverGroup.alpha = 0;
        }
        
        _restartButton.interactable = isNeedToShow;
        _exitButton.interactable = isNeedToShow;
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);        
    }

    public void OnExitButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }    
}
