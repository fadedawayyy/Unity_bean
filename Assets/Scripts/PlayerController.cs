using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Настройки")]
    public float speed = 500f;
    public GameObject footstepEffect;

    [Header("Звуки")]
    public AudioClip rockSound;
    public AudioClip donutSound;

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;
    private float moveX;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (footstepEffect != null) footstepEffect.SetActive(false);
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (moveX != 0)
        {
            if (anim != null) anim.enabled = true;
            if (footstepEffect != null) footstepEffect.SetActive(true);

            // Разворот персонажа (проверь, не слишком ли большое число 48 для твоего спрайта)
            transform.localScale = new Vector3(moveX > 0 ? 48 : -48, 48, 1);
        }
        else
        {
            if (anim != null) anim.enabled = false;
            if (footstepEffect != null) footstepEffect.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        // Используем новую систему velocity для Unity 6
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Я коснулся объекта: " + other.name);
        
        // Ищем скрипт с ценой/очками на упавшем предмете
        ItemValue item = other.GetComponent<ItemValue>();

        if (item != null)
        {
            // Если очки > 0 — это пончик (хороший предмет)
            if (item.points > 0)
            {
                if (audioSource != null && donutSound != null)
                    audioSource.PlayOneShot(donutSound);
            }
            // Если очки <= 0 — это камень или гиря (плохой предмет)
            else
            {
                if (audioSource != null && rockSound != null)
                    audioSource.PlayOneShot(rockSound);

                // Наносим урон через HealthManager
                HealthManager hm = Object.FindFirstObjectByType<HealthManager>();
                if (hm != null) hm.TakeDamage();
            }

            // Добавляем очки (столько, сколько указано в ItemValue предмета)
            ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null) sm.AddScore(item.points);

            // Удаляем предмет после сбора
            Destroy(other.gameObject);
        }
    }
}