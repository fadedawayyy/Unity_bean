using UnityEngine;
using TMPro; // Для TextMeshPro
using UnityEngine.UI; // Для обычного текста

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    [Header("Перетащи сюда ScoreDisplay")]
    public TextMeshProUGUI scoreTextMesh; // Поле для TMP
    public Text scoreTextStandard;        // Поле для обычного текста

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Счет в скрипте вырос: " + score);
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Обновляем тот текст, который ты привязал
        if (scoreTextMesh != null)
        {
            scoreTextMesh.text = "Score: " + score;
        }


        
    }
}