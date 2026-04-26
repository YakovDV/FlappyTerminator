using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.AttackPressed += _shooter.TryShoot;
    }

    private void OnDisable()
    {
        _playerInput.AttackPressed -= _shooter.TryShoot;
    }
}