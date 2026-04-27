using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Jumper), typeof(PlayerInput))]

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private Jumper _jumper;
    private Character _character;

    private Vector3 _startPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _jumper = GetComponent<Jumper>();
        _character = GetComponent<Character>();
    }

    private void Start()
    {
        _startPosition = transform.position;

        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void OnEnable()
    {
        _playerInput.JumpPressed += OnJumpPressed;
        _character.Died += StopMoving;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);

        PositionFix();
    }

    private void OnDisable()
    {
        _playerInput.JumpPressed -= OnJumpPressed;
        _character.Died -= StopMoving;
    }

    private void OnJumpPressed()
    {
        _jumper.Jump(_rigidbody);

        transform.rotation = _maxRotation;
    }

    private void PositionFix()
    {
        Vector3 position = new(_startPosition.x, transform.position.y, _startPosition.z);

        transform.position = position;
    }

    private void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}