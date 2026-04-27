using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class EnemyDespawnZone : MonoBehaviour
{
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.RequestDespawn();
        }
    }
}