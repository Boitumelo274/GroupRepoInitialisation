
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class UImanagement : MonoBehaviour
{
    public GameObject winningPanel;
    public GameObject gameOverMenu;
    private int score;
    public Text scoreText;
    public static treasure Instance;

    [SerializeField] private ParticleSystem confettiLeft;
    [SerializeField] private ParticleSystem confettiRight;



    private void OnEnable()
    {
        Movement.OnGameOver += EnableGameOverMenu;
    }

  

    private void OnDisable()
    {
        Movement.OnGameOver -= EnableGameOverMenu;
    }



    
    public void RestartGame()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene("gameOverScene");

    }


    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void EnableWinningPanel()
    {
        winningPanel.SetActive(true);

        if (confettiLeft != null)
            confettiLeft.Play();

        if (confettiRight != null)
            confettiRight.Play();

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

