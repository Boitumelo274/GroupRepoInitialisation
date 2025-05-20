using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TMP_Text pauseButtonText;
    public AudioSource backgroundMusic;
    public AudioSource sfxSource;
    public AudioClip pauseSFX;


    public GameObject pauseButton;
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pauseMenuUI != null)
                pauseMenuUI.SetActive(true);

            if (pauseButtonText != null)
                pauseButtonText.text = "Resume";

            if (backgroundMusic != null && backgroundMusic.isPlaying)
                backgroundMusic.Pause();

            if (sfxSource != null && pauseSFX != null)
                sfxSource.PlayOneShot(pauseSFX);
        }
        else
        {
            Time.timeScale = 1f;
            if (pauseMenuUI != null)
                pauseMenuUI.SetActive(false);

            if (pauseButtonText != null)
                pauseButtonText.text = "Pause";

            if (backgroundMusic != null)
                backgroundMusic.UnPause();
        }
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //  alternative pause
        {
            TogglePause();
        }
    }

    public void DisablePauseButton()
    {
        if (pauseButton != null)
        {
            Destroy(pauseButton); 
        }
    }
}
