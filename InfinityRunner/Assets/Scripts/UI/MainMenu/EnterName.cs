using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
    [SerializeField] private Text _nameText;
        
    public void Start()
    {
        gameObject.SetActive(false);             
    }

    public void OnPlayButtonClick()
    {
        TopResults.Instance.AddName(_nameText.text);
        
        SceneManager.LoadScene(1);
    }
}
