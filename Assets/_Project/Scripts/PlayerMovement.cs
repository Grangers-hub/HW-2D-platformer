using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput), typeof(GroundDetector))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerInput _input;
    private GroundDetector _groundDetector;
    private bool _isFacingRight = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_input.HorizontalValue));
        HandleRotation(_input.HorizontalValue);
    }

    private void FixedUpdate()
    {
        Move(_input.HorizontalValue);

        if (_input.IsJumpPressed && _groundDetector.IsTouchingGround())
        {
            Jump();
        }
    }

    private void Move(float direction)
    {
        _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
        _input.ConsumeJump(); 
    }

    private void HandleRotation(float direction)
    {
        if (_isFacingRight && direction < 0f || !_isFacingRight && direction > 0f)
        {
            _isFacingRight = !_isFacingRight;

            float yRotation = _isFacingRight ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }
}