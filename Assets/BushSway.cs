using Unity.VisualScripting;
using UnityEngine;

public class BushSway : MonoBehaviour
{
    public float swayAmount = 2f;
    public float swaySpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float anlge = Mathf.Sin(Time.time * swaySpeed) * swaySpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, anlge);
    }
}
