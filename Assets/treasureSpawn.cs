



using UnityEngine;

public class treasureSpawn : MonoBehaviour
{
    public GameObject treasure;
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
            Instantiate(treasure, transform.position, transform.rotation);
            timer = 0;
       
        }
    }
}

