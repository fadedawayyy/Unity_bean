using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Настройки")]
    public float speed = 500f;
    public GameObject footstepEffect; // Сюда перетащи PuffSprite

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
        
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Donut"))
        {
            
            if (audioSource != null && donutSound != null)
            {
                audioSource.PlayOneShot(donutSound);
            }

            ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null) sm.AddScore(1);

            Destroy(other.gameObject);
        }

        
        else if (other.CompareTag("Rock"))
        {
            
            if (audioSource != null && rockSound != null)
            {
                audioSource.PlayOneShot(rockSound);
            }

            HealthManager hm = Object.FindFirstObjectByType<HealthManager>();
            if (hm != null) hm.TakeDamage();

            Destroy(other.gameObject);
        }
    }
}