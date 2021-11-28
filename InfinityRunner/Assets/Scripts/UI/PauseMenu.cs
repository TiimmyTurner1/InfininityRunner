using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Player _player;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _pauseGroup;

    private void Start()
    {
        _pauseGroup = GetComponent<CanvasGroup>();

        ChangeVisibilityPauseMenu(false);
    }

    private void OnEnable()
    {
        _player.Paused += Pause;
    }

    private void OnDisable()
    {
        _player.Paused -= Pause;
    }

    private void Pause()
    {
        ChangeVisibilityPauseMenu(true);
        Time.timeScale = 0;
    }

    private void ChangeVisibilityPauseMenu(bool isNeedToShow)
    {
        if(isNeedToShow == true)
        {
            _pauseGroup.alpha = 1;
        }
        else
        {
            _pauseGroup.alpha = 0;
        }
        
        _resumeButton.interactable = isNeedToShow;
        _restartButton.interactable = isNeedToShow;
        _exitButton.interactable = isNeedToShow;
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
        ChangeVisibilityPauseMenu(false);
        _pauseGroup.alpha = 0;
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
        TopResults.Instance.AddResult(_score.CurrentScore);
    }
}
