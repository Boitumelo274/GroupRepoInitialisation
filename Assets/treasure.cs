using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class treasure : MonoBehaviour
{
    [SerializeField] private int treasureValue;
    public float movespeed = 1f;
    public Transform player;
    public float groundY = -3.5f;
    public float destroyDistance = 0.2f;
    private bool hasTriggered;
    private TreasureManager treasureManager;

    private void Start()
    {
        treasureManager = TreasureManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            treasureManager.ChangeTreasures(treasureValue);
            Destroy(gameObject);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasTriggered = false; // Reset the flag to allow re-triggering if needed
            Destroy(gameObject);
        }
    }

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
        }
    }
}

