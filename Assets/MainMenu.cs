



using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StoryScene()
    {
        SceneManager.LoadScene("CutScene");
    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene("TREASURE-LADEN EAGLES");
    }

    

    public void Introgame()
    {
        SceneManager.LoadScene("EndIntro");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}

