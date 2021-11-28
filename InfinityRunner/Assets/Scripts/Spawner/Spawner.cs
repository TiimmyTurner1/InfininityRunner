using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{        
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _cooldown;

    private float _currentTime = 0;
    private int _prevNumber = -1;    

    private void Start()
    {
        Initialize();        
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _cooldown)
        {
            if(TryGetObject(out GameObject enemy))
            {
                _currentTime = 0;
                int spawnPointNumber = SpawnPointNumber(_spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    public void ChangeCooldown(float value)
    {
        _cooldown = value;
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.GetComponent<Renderer>().enabled = true;
        enemy.transform.position = spawnPoint;
    }

    private int SpawnPointNumber(int maxValue)
    {
        int currentNumber = -1;
        bool isRightNumber = false;        

        while(isRightNumber == false)
        {
            currentNumber = Random.Range(0, maxValue);

            if (_prevNumber != currentNumber)
            {
                isRightNumber = true;
            }
        }

        _prevNumber = currentNumber;

        return currentNumber;
    }

}
