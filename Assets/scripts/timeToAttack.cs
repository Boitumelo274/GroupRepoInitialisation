using UnityEngine;

public class timeToAttack : MonoBehaviour
{
    public float movespeed = 1f;
    public Transform player;
    public float groundY = -3.5f;
    public float destroyDistance = 0.2f;

    public float resY = 20f;
    public float beginY = 20f;
    public float scrollSpeeds = 2f;

    public AudioSource sfxSource;
    public AudioClip eagleSFX;
    public AudioClip bloodSFX;

    private bool hasScreeched = false;

    [Header("Blood Effect")]
    public GameObject bloodPrefab;

    
    private static bool previousNightState = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 playerCenter = collision.collider.bounds.center;

            if (contactPoint.y > playerCenter.y)
            {
                Movement playerHealth = collision.collider.GetComponent<Movement>();
                if (playerHealth != null)
                {
                    playerHealth.takeDamage(5);

                    if (sfxSource != null && bloodSFX != null)
                    {
                        sfxSource.PlayOneShot(bloodSFX);
                    }

                    if (bloodPrefab != null)
                    {
                        GameObject blood = Instantiate(bloodPrefab, playerHealth.transform.position, Quaternion.identity);
                        Destroy(blood, 0.3f);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }

    void Start()
    {
        Invoke(nameof(PlayBirdSound), 0.1f); // slight delay fixes audio init issues
    }

    void PlayBirdSound()
    {
        if (sfxSource != null && eagleSFX != null)
        {
            sfxSource.PlayOneShot(eagleSFX);
        }
    }

    void Update()
    {
        transform.position += Vector3.down * movespeed * Time.deltaTime;

       
        if (previousNightState && !GameSta.isNight)
        {
            if (sfxSource != null && eagleSFX != null)
            {
                sfxSource.PlayOneShot(eagleSFX);
            }
        }

        
        previousNightState = GameSta.isNight;

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < 5f && !hasScreeched)
            {
                if (sfxSource != null && eagleSFX != null)
                {
                    sfxSource.PlayOneShot(eagleSFX);
                    hasScreeched = true;
                }
            }
        }

        if (Mathf.Abs(transform.position.y - groundY) < destroyDistance)
        {
            if (spawner.Instance != null)
            {
                spawner.Instance.spawnEnemy();
            }

            Destroy(gameObject);

            transform.Translate(Vector3.down * scrollSpeeds * Time.deltaTime);
            if (transform.position.y <= -resY)
            {
                Vector3 pos = transform.position;
                pos.y = pos.y + 2 * resY;
                transform.position = pos;

                scrollSpeeds += 20f;
            }
        }
    }
}
