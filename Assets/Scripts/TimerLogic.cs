using UnityEngine;
using TMPro; // Обязательно для работы с текстом

public class TimerLogic : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Сюда перетащим объект текста
    private float startTime;
    private bool isGameActive = true;

    void Start()
    {
        // Запоминаем время начала игры
        startTime = Time.time;
    }

    void Update()
    {
        if (isGameActive)
        {
            // Считаем, сколько времени прошло
            float t = Time.time - startTime;

            // Форматируем в минуты и секунды
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            string milliseconds = ((t * 100) % 100).ToString("00");


            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    
    public void StopTimer()
    {
        isGameActive = false;
    }
}