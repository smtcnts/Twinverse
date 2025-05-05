using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // 🎷 Sesler
    public AudioClip runSound;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip hitSound;

    private AudioSource runLoopSource;   // Koşma sesi loop için

    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 3f;

    private bool isGrounded = true;
    private bool isDead = false;
    private bool isStunned = false;

    private Vector3 startPosition;
    private int jumpCount = 0;
    public int maxJumpCount = 2;

    public int maxHealth = 2;
    private int currentHealth;
    public float knockbackForce = 5f;

    private HealthUI healthUI;
    private float defaultGravityScale;

    public GameObject deathPanel;

    void Start()
    {
        startPosition = transform.position;
        currentHealth = maxHealth;
        defaultGravityScale = rb.gravityScale;

        healthUI = FindObjectOfType<HealthUI>();
        if (healthUI != null)
            healthUI.UpdateHearts(currentHealth);

        if (deathPanel != null)
            deathPanel.SetActive(false);

        runLoopSource = gameObject.AddComponent<AudioSource>();
        runLoopSource.clip = runSound;
        runLoopSource.loop = true;
        runLoopSource.playOnAwake = false;
        runLoopSource.volume = 0.7f;

        // Arka plan müziğini yeniden başlatma (yalnızca bir defa)
        if (!SoundManager.Instance.musicSource.isPlaying)
        {
            SoundManager.Instance.musicSource.clip = SoundManager.Instance.backgroundMusic;
            SoundManager.Instance.musicSource.Play();
        }
    }

    void Update()
    {
        if (isDead || isStunned) return;

        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0)
            transform.localScale = new Vector3(3, 3, 3);
        else if (move < 0)
            transform.localScale = new Vector3(-3, 3, 3);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            float appliedJumpForce = (jumpCount == 0) ? jumpForce : jumpForce * 0.8f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, appliedJumpForce);

            jumpCount++;
            isGrounded = false;
            animator.SetBool("isJumping", true);
            animator.SetBool("isGrounded", false);

            SoundManager.Instance.PlaySFX(jumpSound);
        }

        animator.SetBool("isFalling", rb.linearVelocity.y < -0.1f);

        if (isGrounded && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
        {
            if (!runLoopSource.isPlaying)
                runLoopSource.Play();
        }
        else
        {
            if (runLoopSource.isPlaying)
                runLoopSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Lava"))
        {
            float verticalVelocity = rb.linearVelocity.y;
            float horizontalVelocity = Mathf.Abs(rb.linearVelocity.x);

            if (verticalVelocity < -0.1f || horizontalVelocity > 0.1f)
                StartCoroutine(DieAndShowPanel());
        }
        else if (other.CompareTag("Damla"))
        {
            Rigidbody2D lavaRb = other.GetComponent<Rigidbody2D>();
            if (lavaRb != null && lavaRb.linearVelocity.y < -0.5f)
            {
                Debug.Log("\ud83d\udca7 D\u00fc\u015fen damladan hasar al\u0131nd\u0131.");
                TakeDamage(other.transform.position);
            }
            else
            {
                Debug.Log("\ud83d\udca7 Sabit damla, zarar yok.");
            }
        }
        else if (other.CompareTag("Spike"))
        {
            TakeDamage(other.transform.position);
        }
    }

    public void TakeDamage(Vector2 sourcePosition)
    {
        if (isDead) return;

        currentHealth--;
        if (healthUI != null)
            healthUI.UpdateHearts(currentHealth);

        if (currentHealth > 0)
        {
            animator.SetTrigger("Hit");
            SoundManager.Instance.PlaySFX(hitSound);

            Vector2 knockbackDir = (transform.position - (Vector3)sourcePosition).normalized;
            knockbackDir.y = 0;
            knockbackDir.Normalize();

            float knockDistance = 0.5f;
            transform.position += (Vector3)(knockbackDir * knockDistance);

            rb.linearVelocity = Vector2.zero;
            rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);

            StartCoroutine(StunForSeconds(0.3f));
        }

        if (currentHealth <= 0)
            StartCoroutine(DieAndShowPanel());
    }

    IEnumerator DieAndShowPanel()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = defaultGravityScale;

        currentHealth = 0;
        if (healthUI != null)
            healthUI.UpdateHearts(currentHealth);

        runLoopSource.Stop();
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlaySFX(deathSound);

        animator.SetTrigger("Die");

        yield return new WaitForSeconds(1.5f);

        if (deathPanel != null)
            deathPanel.SetActive(true);
    }

    public void RespawnButtonClicked()
    {
        runLoopSource.Stop();
        SoundManager.Instance.StopAllSounds();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator StunForSeconds(float duration)
    {
        isStunned = true;
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }
}
