using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
     [SerializeField] AudioSource AUDSourced;

    public AudioClip background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }   
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
