using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioSource sfxSource;
    public AudioClip buttonClickSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); 

        DontDestroyOnLoad(gameObject);
    }

    public void PlayButtonClick()
    {
        if (sfxSource != null && buttonClickSound != null)
            sfxSource.PlayOneShot(buttonClickSound);
    }

}
