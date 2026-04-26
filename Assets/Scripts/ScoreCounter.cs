using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    public event Action<int> ValueChanged;

    private int _score;

    private void OnEnable()
    {
        ResetScore();
        _enemySpawner.OnShotByPlayer += AddScore;
    }

    private void OnDisable()
    {
        _enemySpawner.OnShotByPlayer -= AddScore;
    }

    public void ResetScore()
    {
        _score = 0;
    }

    private void AddScore()
    {
        _score++;
        ValueChanged?.Invoke(_score);
    }
}