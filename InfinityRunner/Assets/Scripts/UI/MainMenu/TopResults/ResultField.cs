using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultField : MonoBehaviour
{
    private Text _position;
    private Text _name;
    private Text _score;

    private void Awake()
    {
        Text[] components = GetComponentsInChildren<Text>();
        _position = components[0];
        _name = components[1];
        _score = components[2];
    }

    public void Fill(int position, string name, int score)
    {
        _position.text = position.ToString();
        _name.text = name;
        _score.text = score.ToString() + " " + "m";
    }
}
