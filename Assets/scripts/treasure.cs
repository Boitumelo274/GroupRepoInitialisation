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
    private bool hasTriggered = false;
    private TreasureManager treasureManager;

    public AudioClip collectSFX;
    public AudioSource sfxSource;

    private void Start()
    {
        treasureManager = TreasureManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            if (collectSFX != null)
            {
                
                GameObject audioObj = new GameObject("TempAudio");
                AudioSource audioSource = audioObj.AddComponent<AudioSource>();
                audioSource.PlayOneShot(collectSFX);
                Destroy(audioObj, collectSFX.length); 
            }
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

