using TMPro;
using UnityEngine;




public class TreasureManager : MonoBehaviour
{
    public static TreasureManager instance; 
    private int treasures; 
    [SerializeField] private TMP_Text treasuresDisplay;

    [SerializeField] private int winGoal = 450;
    [SerializeField] private GameObject winPanel;
    private bool hasWon = false;

    public GameObject winningPanel; 

    private void Awake()
    {
        
        if (!instance)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
    }

    private void UpdateUI()
    {
        if(treasuresDisplay != null)
        {
            treasuresDisplay.text = treasures.ToString();
        }
       
    }

    public void ChangeTreasures(int amount)
    {
        treasures += amount;
        UpdateUI();
        Debug.Log("Treasure");

        if(treasures >= winGoal && !hasWon)
        {
            hasWon = true;
            WinGame();
        }
    }

    private void Start()
    {
        if(treasuresDisplay==null)
        {
            treasuresDisplay = GameObject.Find("treasuresDisplay")?.GetComponent<TMP_Text>();

        }

        UpdateUI();
    }

   
    private void WinGame()
    {
        Debug.Log("You Win!");
        FindObjectOfType<UImanagement>()?.EnableWinningPanel();


        Time.timeScale = 0f;
    }


}