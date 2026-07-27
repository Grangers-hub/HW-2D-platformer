using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Настройки маршрута")]
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private Rigidbody2D _rigidbody;
    private Transform _currentTarget;
    private bool _isFacingRight = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentTarget = _pointB;
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector2 direction = (_currentTarget.position - transform.position).normalized;

        _rigidbody.linearVelocity = new Vector2(direction.x * _speed, _rigidbody.linearVelocity.y);

        UpdateRotation(direction.x);

        float distanceToTarget = Mathf.Abs(transform.position.x - _currentTarget.position.x);

        if (distanceToTarget < 0.2f)
        {
            SwitchTarget();
        }
    }

    private void SwitchTarget()
    {
        if (_currentTarget == _pointA)
        {
            _currentTarget = _pointB;
        }
        else
        {
            _currentTarget = _pointA;
        }
    }

    private void UpdateRotation(float directionX)
    {
        if (_isFacingRight && directionX < 0f || !_isFacingRight && directionX > 0f)
        {
            _isFacingRight = !_isFacingRight;
            float yRotation = _isFacingRight ? 180f : 0f;
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }
}