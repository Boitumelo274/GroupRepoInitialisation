

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int totalTreasure = 0;

    public void AddTreasure(int amount)
    {
        totalTreasure += amount;
        Debug.Log("Treasure Collected! Total: " + totalTreasure);
    }
    
   
}


