using UnityEngine;

public class TreasureGlow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color glowColor = new Color(1.5f, 1.3f, 0.6f); 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void Update()
    {
        if (spriteRenderer == null) return;

        if (GameSta.isNight)
        {
            spriteRenderer.color = glowColor;

        }
        else
        {
            // Restore normal color
            spriteRenderer.color = originalColor;
        }
    }
}
