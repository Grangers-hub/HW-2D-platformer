using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Настройки слежения")]
    [SerializeField] private Transform _target; 
    [SerializeField] private float _smoothSpeed = 5f;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 2f, -10f); 

    private void LateUpdate()
    {
        if (_target == null)
            return;

        Vector3 desiredPosition = _target.position + _offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
    }
}