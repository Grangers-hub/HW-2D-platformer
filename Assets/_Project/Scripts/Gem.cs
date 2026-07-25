using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int _pointsValue = 1; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(_pointsValue);

            Destroy(gameObject);
        }
    }
}