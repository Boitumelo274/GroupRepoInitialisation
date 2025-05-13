
using System;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject gameOverPanel;

    public float moveSpeed = 5f;
    private int currentLane = 1;
    public float[] lanePositions = new float[] { -2f, 0f, 2f };

    public static event Action OnGameOver;
    public int health = 100;
    public float maxHealth = 100;
    public Image healthBar;
    
    public float speed = 0f;

    private bool isGameOver = false;

    public void takeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 100);// limit

        print("Health :" + health);

        if (health <=0 && !isGameOver)
        {
            isGameOver = true;
            print("Game Over!");

          if(gameOverPanel!=null)
          {
                gameOverPanel.SetActive(true);
          }
            OnGameOver?.Invoke();
         Time.timeScale= 0f;// lets pause the game.


        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentLane > 0)
        {
            currentLane--;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && currentLane < lanePositions.Length - 1)
        {
            currentLane++;
        }
        Vector3 targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

       

        health = Mathf.Clamp(health, 0, 100);// limit

        if (isGameOver) return;

        if (health > 0)
        {
            speed += 2f * Time.deltaTime;
            print("Player speed: " + speed);
        }

        healthBar.fillAmount = Mathf.Clamp(health / maxHealth,0,1);

    }

}

