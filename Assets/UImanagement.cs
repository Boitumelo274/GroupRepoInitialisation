
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UImanagement : MonoBehaviour
{
    public GameObject winningPanel;
    public GameObject[] nextLevelTreasures;

    public AudioClip winSFX;
    public AudioClip looseSFX;
    public AudioSource backgroundMusic;
    public AudioSource sfxSource;



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

    public void CutScene2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CutScene2");
    }


    
    public void RestartGame()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene("gameOverScene");

    }


    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);


        if (backgroundMusic != null && backgroundMusic.isPlaying)
            backgroundMusic.Pause();

        // Play LOOSING SFX
        if (sfxSource != null && looseSFX != null)
            sfxSource.PlayOneShot(looseSFX);
    }

    public void EnableWinningPanel()
    {
        winningPanel.SetActive(true);

        if (backgroundMusic != null && backgroundMusic.isPlaying)
            backgroundMusic.Pause();

        // Play cheering SFX
        if (sfxSource != null && winSFX != null)
            sfxSource.PlayOneShot(winSFX);

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

    public void OnContinueButtonPressed()
    {
        // Resume game
        Time.timeScale = 1f;

        // Hide win panel
        if (winningPanel != null)
            winningPanel.SetActive(false);

        //  Destroy old treasures
        foreach (var old in GameObject.FindGameObjectsWithTag("Treasure"))
        {
            Destroy(old);
        }

        // Spawn new treasures for the next level
        foreach (GameObject treasure in nextLevelTreasures)
        {
            Instantiate(treasure, GetRandomSpawnPoint(), Quaternion.identity);
        } 
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-5, 5), 1f, Random.Range(-5, 5));
    }


}

