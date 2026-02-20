using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 500f;
    public GameObject footstepEffect;

    private Rigidbody2D rb;
    private Animator anim;
    private float moveX; // Выносим переменную сюда

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Считываем нажатия клавиш здесь
        moveX = Input.GetAxisRaw("Horizontal");

        // Логика анимации и следа
        if (moveX != 0)
        {
            if (anim != null) anim.enabled = true;
            if (footstepEffect != null) footstepEffect.SetActive(true);

            // Здесь поменяй 100 на свой скейл (например, 50), если он растет
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
        // Двигаем персонажа через физику ( velocity )
        // Теперь дома с коллайдерами будут его останавливать автоматически!
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    // Чтобы собирать пончики, когда Is Trigger выключен:
    // Для "твердого" Бина используем OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем тег объекта, с которым столкнулись
        if (collision.gameObject.CompareTag("Donut"))
        {
            ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null)
            {
                sm.AddScore(1);
            }

            // Удаляем пончик после столкновения
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Камень попал в Бина!");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Donut"))
        {
            ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null) sm.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Rock"))
        {
            Destroy(other.gameObject);
        }
    }
}