using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultFieldList
{
    public string Name { get; private set; }
    public int Score { get; private set; }

    public ResultFieldList(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
