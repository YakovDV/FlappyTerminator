using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    public event Action<Enemy> Died;
    public event Action KilledByPlayer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void HandleBulletHit(BulletOwner bulletOwner)
    {
        if (bulletOwner == BulletOwner.Player)
        {
            KilledByPlayer?.Invoke();
            RequestDespawn();
        }
    }

    public void RequestDespawn()
    {
        Died?.Invoke(this);
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