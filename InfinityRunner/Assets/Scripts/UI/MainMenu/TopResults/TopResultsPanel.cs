using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TopResultsPanel : MonoBehaviour
{
    [SerializeField] private Button _refreshButton;
    [SerializeField] private Button _exitButton;

    private AudioSource _audioSource;

    public UnityAction DeleteRows;

    private void Start()
    {
        _audioSource = _exitButton.GetComponent<AudioSource>();
    }

    public void OnRefreshButtonClick()
    {
        TopResults.Instance.RefreshTable();
        _refreshButton.interactable = false;
    }

    public void OnExitButtonClick()
    {
        DeleteRows?.Invoke();        

        if (_refreshButton.interactable == false)
        {
            _refreshButton.interactable = true;
        }


        _audioSource.PlayOneShot(_audioSource.clip);
        Invoke("ClosePanel", _audioSource.clip.length);        
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
