using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{    
    [Tooltip("descending from frequent to rare in pool")]
    [SerializeField] private GameObject[] _enemyTemplates;    
    [Range(0f, 100f)]
    [SerializeField] private int[] _enemiesCountInPool;
    [SerializeField] private GameObject _container;    

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize()
    {
        for (int i = 0; i < _enemyTemplates.Length; i++)
        {
            for (int j = 0; j < _enemiesCountInPool[i]; j++)
            {                
                GameObject spawned = Instantiate(_enemyTemplates[i], _container.transform);
                spawned.tag = "Enemy";
                spawned.SetActive(false);
                _pool.Add(spawned);
            }
        }
    }

    public void ChangeSpeed(float value)
    {
        foreach (GameObject enemy in _pool)
        {
            enemy.GetComponent<EnemyMover>().ChangeSpeed(value);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        RefreshList(ref _pool);
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    private void RefreshList(ref List<GameObject> list)
    {
        list = list.OrderBy(v => Random.Range(0, 100)).ToList();
    }
}
