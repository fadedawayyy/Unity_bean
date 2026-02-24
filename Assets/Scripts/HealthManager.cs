using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections; // Нужно для задержки

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
    public GameObject gameOverPanel;

    [Header("Звуки")]
    public AudioClip gameOverSound; // Звук при смерти
    public AudioClip restartSound;  // Звук при нажатии Restart
    private AudioSource audioSource;

    void Start()
    {
        // Получаем или добавляем компонент AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();

        // Чтобы звуки не затихали при паузе
        audioSource.ignoreListenerPause = true;
    }

    public void TakeDamage()
    {
        if (health <= 0) return;

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
        // 1. Проигрываем звук смерти
        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

        // 2. Показываем панель
        gameOverPanel.SetActive(true);

        // 3. Останавливаем время
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Запускаем корутину, чтобы звук успел проиграться перед перезагрузкой сцены
        StartCoroutine(RestartWithSound());
    }

    IEnumerator RestartWithSound()
    {
        // Проигрываем звук рестарта
        if (audioSource != null && restartSound != null)
        {
            audioSource.PlayOneShot(restartSound);
        }

        // Ждем немного времени (в реальных секундах, т.к. timeScale = 0)
        yield return new WaitForSecondsRealtime(0.5f);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}