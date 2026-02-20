using UnityEngine;
using TMPro; // Подключаем библиотеку для работы с современным текстом

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    // Заменяем обычный Text на TextMeshProUGUI
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        // Проверяем, привязан ли текст, чтобы не было ошибок в консоли
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}