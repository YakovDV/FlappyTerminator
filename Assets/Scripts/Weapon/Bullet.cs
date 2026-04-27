using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Renderer), typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    public event Action<Bullet> ReadyToReturn;

    public BulletOwner Owner { get; private set; }

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.HandleBulletHit(Owner);
        }

        ReadyToReturn?.Invoke(this);
    }

    public void Move(Vector2 direction)
    {
        direction = direction.normalized;
        _rigidbody.velocity = direction * _speed;

        Rotate(direction);
    }

    public void SetOwner(BulletOwner owner)
    {
        Owner = owner;
    }

    private void Rotate(Vector2 direction)
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
    }
}