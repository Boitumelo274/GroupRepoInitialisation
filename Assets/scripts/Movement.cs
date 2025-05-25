using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public ParticleSystem dust;
    public GameObject gameOverPanel;
    public AudioSource sfxSource;
    public AudioClip moving;
    public AudioClip gruntSFX;

    public float moveSpeed = 5f;
    private int currentLane = 1;
    public float[] lanePositions = new float[] { -2f, 0f, 2f };

    public static event Action OnGameOver;
    public int health = 100;
    public float maxHealth = 100;
    public Image healthBar;

    public float speed = 0f;

    private bool isShaking = false;
    private float shakeDuration = 0.2f;
    private float shakeTimer = 0f;
    private float shakeMagnitude = 0.1f;
    private Vector3 originalPosition;

    private bool isGameOver = false;

    public void takeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 100);

        print("Health :" + health);
        if (sfxSource != null && gruntSFX != null)
        {
            sfxSource.PlayOneShot(gruntSFX);
        }

        if (!isGameOver)
        {
            StartShake();
        }

        if (health <= 0 && !isGameOver)
        {
            isGameOver = true;
            print("Game Over!");

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
            OnGameOver?.Invoke();
            Time.timeScale = 0f;
        }
    }

    public void addHealth(int amount)
    {
        health += amount;
        Debug.Log("Health increased to " +  health);
    }

    void Start()
    {
        SetupDust();
        originalPosition = transform.localPosition;

    }

    void Update()
    {
        if (isGameOver) return;

        bool moved = false;

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentLane > 0)
        {
            currentLane--;
            moved = true;

        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && currentLane < lanePositions.Length - 1)
        {
            currentLane++;
            moved = true;
        }

        if (moved)
        {
            CreateDust();

            if(sfxSource != null && moving != null)
            {
                sfxSource.PlayOneShot(moving);
            }
        }

        Vector3 targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        

        health = Mathf.Clamp(health, 0, 100);
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (isShaking)
        {
            shakeTimer -= Time.deltaTime;
            transform.localPosition = originalPosition + (Vector3)UnityEngine.Random.insideUnitCircle * shakeMagnitude;

            if (shakeTimer <= 0f)
            {
                isShaking = false;
                transform.localPosition = originalPosition;
            }
        }
    }

    void CreateDust()
    {
        if (dust != null)
        {
            dust.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            dust.Play();
        }
    }

    void SetupDust()
    {
        if (dust != null)
        {
            var main = dust.main;
            main.duration = 0.5f;
            main.startLifetime = 0.5f;

            var colorOverLifetime = dust.colorOverLifetime;
            colorOverLifetime.enabled = true;

            Gradient grad = new Gradient();
            grad.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
            );
            colorOverLifetime.color = new ParticleSystem.MinMaxGradient(grad);
        }
    }

    void StartShake()
    {
        isShaking = true;
        shakeTimer = shakeDuration;
        originalPosition = transform.localPosition;

    }
}