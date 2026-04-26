using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    public event Action<Enemy> ReadyToReturn;
    public event Action<Enemy> ShotByPlayer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bullet>(out Bullet bullet) || collision.TryGetComponent<Despawner>(out Despawner component))
        {
            if (bullet?.Owner == BulletOwner.Player)
            {
                ShotByPlayer?.Invoke(this);
            }

            ReadyToReturn?.Invoke(this);
        }
    }

    public void Move(Vector2 direction)
    {
        direction = direction.normalized;
        _rigidbody.velocity = direction * _speed;

        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
    }
}