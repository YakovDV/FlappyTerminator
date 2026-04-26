using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private Transform _origin;
    [SerializeField] private float _delay;
    [SerializeField] private float _minY = -3f;
    [SerializeField] private float _maxY = 3f;

    public event Action OnShotByPlayer;

    private IEnumerator Start()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (true)
        {
            Enemy enemy = _enemyPool.GetObject();
            enemy.transform.position = CalculateSpawnPoint();
            enemy.ReadyToReturn += ReturnEnemy;
            enemy.ShotByPlayer += HandleShotByPlayer;

            enemy.Move(Vector2.left);

            yield return delay;
        }
    }

    private void HandleShotByPlayer(Enemy enemy)
    {
        enemy.ShotByPlayer -= HandleShotByPlayer;
        OnShotByPlayer?.Invoke();
    }

    private Vector2 CalculateSpawnPoint()
    {
        float yPosition = UnityEngine.Random.Range(_minY, _maxY);
        return new Vector2(_origin.position.x, yPosition);
    }

    private void ReturnEnemy(Enemy enemy)
    {
        enemy.ReadyToReturn -= ReturnEnemy;
        enemy.ShotByPlayer -= HandleShotByPlayer;

        _enemyPool.ReleaseObject(enemy);
    }
}