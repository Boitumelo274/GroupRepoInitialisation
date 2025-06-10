using UnityEngine;

public class EnemySpawnerScrip : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float spawnRangex;

    public float gravityScale = 0.001f; 
    public float gravityIncreaseRate = 0.1f;
    public float gravityMax = 10f;
    void Update()
    {
        if (GameSta.isNight) return;

        // Only increase gravity scale over time
        if (gravityScale < gravityMax)
        {
            gravityScale += gravityIncreaseRate * Time.deltaTime;
            Debug.Log("gravityScale " + gravityScale);
        }

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnRangex = Random.Range(-12f, 0f);
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
