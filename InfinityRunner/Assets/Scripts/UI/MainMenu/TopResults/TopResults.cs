using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;
using UnityEngine.Events;
using System;

public class TopResults : MonoBehaviour
{    
    [SerializeField] int _rowsCount;

    private ResultField[] _rows;

    public static TopResults Instance { get; private set; }
    public UnityAction CreateRows;    

    private List<ResultFieldList> _results;
    private string _currentName;    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);
    }

    private void Start()
    {        
        _results = new List<ResultFieldList>(0);
    }

    public void RefreshTable()
    {        
        CreateRows?.Invoke();

        _rows = FindObjectsOfType<ResultField>();
        Array.Reverse(_rows);

        OrderResultList();
        
        for (int i = 0; i < _results.Count; i++)
        {
            int position = i + 1;

            _rows[i].Fill(position, _results[i].Name, _results[i].Score);
        }             
    }

    private void OrderResultList()
    {
        var sortedResults = _results.OrderByDescending(result => result.Score);
        _results = sortedResults.ToList();
    }

    public void AddResult(int score)
    {
        _results.Add(new ResultFieldList(_currentName, score));

        OrderResultList();

        if(_results.Count > _rowsCount)
        {
            _results.RemoveAt(_results.Count - 1);
        }
    }

    public void AddName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            _currentName = "Anon";
        }
        else
        {
            _currentName = name;
        }
    }
}


