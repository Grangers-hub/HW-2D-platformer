using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddPoints(int points)
    {
        _score += points;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Гемы: " + _score;
        }
    }
}