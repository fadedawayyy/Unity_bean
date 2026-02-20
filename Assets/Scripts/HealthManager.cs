using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int health = 3;

    [Header("Объекты сердец")]
    public SpriteRenderer heartDisplay1;
    public SpriteRenderer heartDisplay2;
    public SpriteRenderer heartDisplay3;

    [Header("Спрайты состояний")]
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Настройки размеров")]
    public float fullHeartScale = 33f;
    public float emptyHeartScale = 10f;

    [Header("UI Проигрыша")]
    public GameObject gameOverPanel; // Сюда перетащи панель из Canvas

    public void TakeDamage()
    {
        if (health <= 0) return; // Чтобы нельзя было бить труп

        health -= 1;
        UpdateHeartsUI();

        if (health <= 0)
        {
            ShowGameOver();
        }
    }

    void UpdateHeartsUI()
    {
        SetHeartState(heartDisplay3, health < 3);
        SetHeartState(heartDisplay2, health < 2);
        SetHeartState(heartDisplay1, health < 1);
    }

    void SetHeartState(SpriteRenderer display, bool isEmpty)
    {
        if (display == null) return;
        if (isEmpty)
        {
            display.sprite = emptyHeart;
            display.transform.localScale = new Vector3(emptyHeartScale, emptyHeartScale, 1);
        }
        else
        {
            display.sprite = fullHeart;
            display.transform.localScale = new Vector3(fullHeartScale, fullHeartScale, 1);
        }
    }

    void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Показываем экран смерти
        Time.timeScale = 0f; // Полностью останавливаем время в игре (Бин не сможет ходить)
    }

    // Этот метод мы привяжем к кнопке
    public void RestartGame()
    {
        Time.timeScale = 1f; // Возвращаем время в норму перед перезагрузкой
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}