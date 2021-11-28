using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _scorePerSecond;
    [SerializeField] private int _level2Score;
    [SerializeField] private int _level3Score;
        
    private bool _levelChanged;

    public int CurrentScore { get; private set; }

    public event UnityAction NextLevel;

    private void Start()
    {
        CurrentScore = 0;
        _levelChanged = false;

        StartCoroutine(AddScore());
    }

    private void Update()
    {        
        _scoreText.text = CurrentScore.ToString();

        if((CurrentScore == _level2Score || CurrentScore == _level3Score))
        {
            if(_levelChanged == false)
            {
                NextLevel?.Invoke();
                _levelChanged = true;
            }            
        }
        else 
        {
            _levelChanged = false;
        }
    }

    private IEnumerator AddScore()
    {
        while (true)
        {
            CurrentScore += _scorePerSecond;
            yield return new WaitForSeconds(1);
        }
    }

    public void ChangeScorePerSecond(int value)
    {
        _scorePerSecond = value;
    }
}
