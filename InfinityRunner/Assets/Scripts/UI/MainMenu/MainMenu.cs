using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pressEnterTitle;    
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _resultsButton;
    [SerializeField] private GameObject _enterNameWindow;
    [SerializeField] private GameObject _topResults;    

    private Image _pressEnterImage;
    private Text _playButtonText;
    private Text _exitButtonText;
    private Text _resultsButtonText;

    private void Start()
    {
        _pressEnterImage = _pressEnterTitle.GetComponent<Image>();
        _playButtonText = _playButton.GetComponentInChildren<Text>();
        _exitButtonText = _exitButton.GetComponentInChildren<Text>();
        _resultsButtonText = _resultsButton.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && _pressEnterTitle.activeSelf)
        {
            StartCoroutine(Filling(1, 0, _duration, _pressEnterImage));
            _playButton.SetActive(true);    
            StartCoroutine(Filling(0, 1, _duration, _playButtonText));
            _exitButton.SetActive(true);
            StartCoroutine(Filling(0, 1, _duration, _exitButtonText));
            _resultsButton.SetActive(true);
            StartCoroutine(Filling(0, 1, _duration, _resultsButtonText));
        }
    }

    public void OnPlayButtonClick()
    {
        _enterNameWindow.SetActive(true);        
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnResultsButtonClick()
    {
        _topResults.SetActive(true);
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, Image image)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            Color tempColor = image.color;
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            tempColor.a = nextValue;
            image.color = tempColor;
            elapsed += Time.deltaTime;
            yield return null;
        }

        _pressEnterTitle.SetActive(false);
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, Text text)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            Color tempColor = text.color;
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            tempColor.a = nextValue;
            text.color = tempColor;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
