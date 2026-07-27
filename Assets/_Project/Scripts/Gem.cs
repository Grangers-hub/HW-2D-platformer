using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int _pointsValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Player player))
        {
            ScoreManager.Instance.AddPoints(_pointsValue);
            Destroy(gameObject);
        }
    }
}