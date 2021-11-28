using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private GameObject _fieldTemplate;
    [SerializeField] private TopResultsPanel _topResultsPanel;
    [SerializeField] private int _rowsCount;

    private void OnEnable()
    {
        TopResults.Instance.CreateRows += CreateRows;
        _topResultsPanel.DeleteRows += DeleteRows;
    }

    private void OnDisable()
    {
        TopResults.Instance.CreateRows -= CreateRows;
        _topResultsPanel.DeleteRows -= DeleteRows;
    }

    private void CreateRows()
    {
        for(int i = 0; i < _rowsCount; i++)
        {
            Instantiate(_fieldTemplate,this.transform).transform.SetParent(this.transform);            
        }
    }

    private void DeleteRows()
    {
        GameObject[] rowsToDelete = GameObject.FindGameObjectsWithTag("Field");

        foreach (GameObject row in rowsToDelete)
        {
            Destroy(row);
        }
    }
}
