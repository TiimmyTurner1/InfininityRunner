using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private GameObject _spawner;
    [SerializeField] private Text _nextLevelText;
    [Header("Level 2")]
    [SerializeField] private float _level2Speed;
    [SerializeField] private float _level2SpawnerCooldown;
    [SerializeField] private int _level2ScorePerSecond;
    [Header("Level 3")]
    [SerializeField] private float _level3Speed;
    [SerializeField] private float _level3SpawnerCooldown;
    [SerializeField] private int _level3ScorePerSecond;

    private int _currentLevel;
    private Spawner _spawnerComponent;
    private PlayerMover _playerMover;
    private EnemyMover[] _enemyMovers;
    private GameObject[] _enemies;

    private void Start()
    {
        _currentLevel = 1;
        _spawnerComponent = _spawner.GetComponent<Spawner>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {        
        _score.NextLevel += NextLevel;
    }

    private void OnDisable()
    {
        _score.NextLevel -= NextLevel;
    }

    private void NextLevel()
    {
        _enemyMovers = FindObjectsOfType<EnemyMover>(true);
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(false);
        }

        ShowNextLevelLabel();        

        switch (_currentLevel)
        {
            case 1:
                ChangeStats(_level2Speed, _level2SpawnerCooldown, _level2ScorePerSecond);
                break;

            case 2:
                ChangeStats(_level3Speed, _level3SpawnerCooldown, _level3ScorePerSecond);
                break;
        }
    }

    private void ShowNextLevelLabel()
    {        
        _nextLevelText.color = new Color(255, 255, 255, 1);
        _nextLevelText.DOColor(new Color(255, 255, 255, 0), 2);        
    }

    private void ChangeStats(float speed, float cooldown, int scorePerSecond)
    {
        foreach (var enemy in _enemyMovers)
        {
            enemy.ChangeSpeed(speed);
        }

        _score.ChangeScorePerSecond(scorePerSecond);
        _spawnerComponent.ChangeCooldown(cooldown);
        _playerMover.ChangeSpeed(speed);
        _currentLevel++;        
    }
}
