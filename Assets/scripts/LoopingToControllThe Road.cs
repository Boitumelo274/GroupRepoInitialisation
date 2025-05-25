



using UnityEngine;

public class LoopingToControllTheRoad : MonoBehaviour
{
    public float resetY = 20f;
    public float startY = 20f;
    public float scrollSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        if(transform.position.y<= -resetY)
        {
            Vector3 pos = transform.position;
            pos.y = pos.y + 2 * resetY;
            transform.position = pos;

           // scrollSpeed = scrollSpeed + 2f;
        }
    }
}

