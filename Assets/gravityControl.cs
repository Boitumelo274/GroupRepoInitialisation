using UnityEngine;

public class BirdGravityController : MonoBehaviour
{
    public float gravityIncrement = 0.05f;    // Amount to increase each interval
    public float maxGravityScale = 1f;       // Maximum gravity scale limit
    public float increaseInterval = 2f;      // Time in seconds between each increase

    private Rigidbody2D rb;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody2D found on this GameObject.");
        }
        else
        {
            rb.gravityScale = 0f;  // Start with no gravity
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= increaseInterval)
        {
            IncreaseGravity();
            timer = 0f;
        }
    }

    void IncreaseGravity()
    {
        if (rb.gravityScale < maxGravityScale)
        {
            rb.gravityScale += gravityIncrement;

            // Clamp to the maximum value
            if (rb.gravityScale > maxGravityScale)
                rb.gravityScale = maxGravityScale;

            Debug.Log("Gravity scale increased to: " + rb.gravityScale);
        }
    }
}
