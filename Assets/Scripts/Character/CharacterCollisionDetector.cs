using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class CharacterCollisionDetector : MonoBehaviour
{
    private Collider2D _collider2D;

    public event Action<Collider2D> CollisionDetected;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CollisionDetected?.Invoke(collider);
    }
}