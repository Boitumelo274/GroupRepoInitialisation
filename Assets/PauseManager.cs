using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TMP_Text pauseButtonText;


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
        }
        else
        {
            Time.timeScale = 1f;
            if (pauseMenuUI != null)
                pauseMenuUI.SetActive(false);

            if (pauseButtonText != null)
                pauseButtonText.text = "Pause";
        }
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //  alternative pause
        {
            TogglePause();
        }
    }
}
