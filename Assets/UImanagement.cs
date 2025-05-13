
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class UImanagement : MonoBehaviour
{
    public GameObject gameOverMenu;
    private int score;
    public Text scoreText;
    public static treasure Instance;

    private void OnEnable()
    {
        Movement.OnGameOver += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        Movement.OnGameOver -= EnableGameOverMenu;
    }



    public void RetryGame()
    {
        UpdateScoreUI();

        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

  
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        UpdateScoreUI();
    }

}

