using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialSpeed = 5f;
    public float speedIncrease = 0.5f; // how much speed increases each hit
    private float currentSpeed;
    public AudioClip paddleHitsound;
    private AudioSource audioSource;

    void Start()
    {
        currentSpeed = initialSpeed;
        LaunchBall();

        audioSource= GetComponent<AudioSource>();
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        Vector2 dir = new Vector2(x, y).normalized;
        rb.linearVelocity = dir * currentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Increase speed after paddle hit
            currentSpeed += speedIncrease;

            // Keep same direction but with higher speed
            rb.linearVelocity = rb.linearVelocity.normalized * currentSpeed;

            // playing hit sound when ball gets hit 
            if (paddleHitsound != null)
            {
                audioSource.PlayOneShot(paddleHitsound);
            }
        }
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        currentSpeed = initialSpeed;
        LaunchBall();
    }
}
