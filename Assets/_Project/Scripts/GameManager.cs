using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Èםעונפויס")]
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void AddScore(int points)
    {
        _score += points;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Ãולû: " + _score.ToString();
        }
    }
}