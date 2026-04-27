using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterCollisionDetector _characterCollisionDetector;
    [SerializeField] private Transform _startPosition;

    public event Action Died;

    private void OnEnable()
    {
        _characterCollisionDetector.CollisionDetected += HandleDeath;
    }

    private void OnDisable()
    {
        _characterCollisionDetector.CollisionDetected -= HandleDeath;
    }

    public void ResetPosition()
    {
        transform.position = _startPosition.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void HandleDeath(Collider2D collider)
    {
        if (collider.TryGetComponent<Killer>(out _))
        {
            Died?.Invoke();
        }
    }
}