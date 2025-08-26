// P2.cs
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class P2 : MonoBehaviour
{
    public Transform ball;                 // Drag the Ball here (or tag the ball as "Ball")
    public float speed = 7f;               // Paddle speed
    [Range(0f, 1f)] public float tracking = 0.15f; // 0=slow reaction, 1=perfect lock
    public bool autoBoundsFromCamera = true;

    public float topBound = 4f;            // Used if autoBoundsFromCamera = false
    public float bottomBound = -4f;

    private Rigidbody2D rb;
    private float targetY;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;   // correct way now
        targetY = transform.position.y;
    }

    void Start()
    {
        // Auto-find ball by tag if not assigned
        if (ball == null)
        {
            var ballGO = GameObject.FindGameObjectWithTag("Ball");
            if (ballGO != null) ball = ballGO.transform;
        }

        // Compute bounds from camera + paddle size so it never leaves the screen
        if (autoBoundsFromCamera && Camera.main != null)
        {
            var halfHeight = GetComponent<Collider2D>().bounds.extents.y;
            float camHalf = Camera.main.orthographicSize;
            topBound = camHalf - halfHeight;
            bottomBound = -topBound;
        }
    }

    void FixedUpdate()
    {
        if (ball == null) return;

        // Simulate reaction time: slowly aim at ball's Y instead of snapping
        targetY = Mathf.Lerp(targetY, ball.position.y, tracking);

        // Move towards the target
        float newY = Mathf.MoveTowards(rb.position.y, targetY, speed * Time.fixedDeltaTime);

        // Keep the paddle inside vertical bounds
        newY = Mathf.Clamp(newY, bottomBound, topBound);

        rb.MovePosition(new Vector2(rb.position.x, newY));
    }
}
