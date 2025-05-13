using TMPro;
using UnityEngine;




public class TreasureManager : MonoBehaviour
{
    public static TreasureManager instance; 
    private int treasures; 
    [SerializeField] private TMP_Text treasuresDisplay;


    private void Awake()
    {
        
        if (!instance)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
    }

    private void OnGUI()
    {
        if(treasuresDisplay != null)
        {
            treasuresDisplay.text = treasures.ToString();
        }
       
    }

    public void ChangeTreasures(int amount)
    {
        treasures += amount; 

    }



}