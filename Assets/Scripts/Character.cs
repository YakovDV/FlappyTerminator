using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterCollisionDetector _characterCollisionDetector;

    public event Action Died;

    private void OnEnable()
    {
        _characterCollisionDetector.CollisionDetected += HandleDeath;
    }

    private void OnDisable()
    {
        _characterCollisionDetector.CollisionDetected -= HandleDeath;
    }

    private void HandleDeath(Collider2D collider)
    {
        if (collider.TryGetComponent<Killer>(out Killer killer))
        {
            Died?.Invoke();
        }
    }
}