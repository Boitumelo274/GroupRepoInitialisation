



using UnityEngine;

public class EnemySpawnerScrip : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }


    }
}
