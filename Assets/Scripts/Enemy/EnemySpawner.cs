using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private Transform _origin;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _delay;
    [SerializeField] private float _minY = -3f;
    [SerializeField] private float _maxY = 3f;

    public event Action EnemyKilledByPlayer;

    private IEnumerator Start()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (true)
        {
            Enemy enemy = _enemyPool.GetObject();
            enemy.transform.position = CalculateSpawnPoint();
            SetEnemyBulletPool(enemy);
            enemy.Died += ReturnEnemy;
            enemy.KilledByPlayer += OnEnemyKilledByPlayer;

            enemy.Move(Vector2.left);

            yield return delay;
        }
    }

    private Vector2 CalculateSpawnPoint()
    {
        float yPosition = UnityEngine.Random.Range(_minY, _maxY);
        return new Vector2(_origin.position.x, yPosition);
    }

    private void SetEnemyBulletPool(Enemy enemy)
    {
        Shooter shooter = enemy.GetComponentInChildren<Shooter>();

        if(shooter != null)
        {
            shooter.SetBulletPool(_bulletPool);
        }
    }

    private void ReturnEnemy(Enemy enemy)
    {
        enemy.Died -= ReturnEnemy;
        enemy.KilledByPlayer -= OnEnemyKilledByPlayer;

        _enemyPool.ReleaseObject(enemy);
    }

    private void OnEnemyKilledByPlayer()
    {
        EnemyKilledByPlayer?.Invoke();
    }
}