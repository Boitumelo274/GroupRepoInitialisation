using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource AUDSourced;


    public AudioClip background;
    public AudioClip birdSound1;
    public AudioClip birdSound2;
    public AudioClip bloodSpit;
    public AudioClip buttons;
    public AudioClip pauseMenu;
    public AudioClip movement;
    public AudioClip treasureSound;

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
