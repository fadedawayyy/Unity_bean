using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Панель паузы
    private bool isPaused = false;

    void Update()
    {
        // Проверяем нажатие Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true); // Показываем надпись "ПАУЗА"
        Time.timeScale = 0f;        // Останавливаем всё в игре
    }

    void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false); // Прячем надпись
        Time.timeScale = 1f;         // Возвращаем движение
    }
}