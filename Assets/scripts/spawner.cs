

using UnityEngine;

public class spawner : MonoBehaviour
{
    public static spawner Instance;

    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnHeight = 10f;
    public float spawnRangeX = 5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void spawnEnemy()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
