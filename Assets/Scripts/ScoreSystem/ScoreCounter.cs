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
        _enemySpawner.EnemyKilledByPlayer += AddScore;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyKilledByPlayer -= AddScore;
    }

    public void ResetScore()
    {
        _score = 0;
        ValueChanged?.Invoke(_score);
    }

    private void AddScore()
    {
        _score++;
        ValueChanged?.Invoke(_score);
    }
}