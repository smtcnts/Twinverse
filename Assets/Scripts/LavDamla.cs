using UnityEngine;

public class LavDamla : MonoBehaviour
{
    private Animator animator;
    private bool hasLanded = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasLanded || !other.CompareTag("Ground")) return;

        hasLanded = true;

        animator.SetTrigger("ImpactNow");

        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        var col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        gameObject.tag = "Untagged";

        Invoke(nameof(DestroySelf), 1.0f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
