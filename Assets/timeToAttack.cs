


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
                }
            }
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * movespeed * Time.deltaTime;
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

                scrollSpeeds = scrollSpeeds+20f;
            }
        }
    }
}

