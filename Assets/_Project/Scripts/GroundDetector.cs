using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _radius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsTouchingGround()
    {
        return Physics2D.OverlapCircle(_groundCheckPoint.position, _radius, _groundLayer);
    }
}