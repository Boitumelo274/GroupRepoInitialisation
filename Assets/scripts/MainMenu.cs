



using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StoryScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("CutScene");
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("TREASURE-LADEN EAGLES");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Introgame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("EndIntro");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   

}

