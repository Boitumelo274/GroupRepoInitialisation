using UnityEngine;

public class GameManager2D : MonoBehaviour
{
    public GameObject choicePanel;
  
    public Movement character;
   
   

    public void TriggerMysteryBox()
    {
        Time.timeScale = 0f;
        choicePanel.SetActive(true);
    }

    public void ChooseAbsorb()
    {
        character.addHealth(25);
        ResumeGame();
    }


    void ResumeGame()
    {
        Time.timeScale = 1f;
        choicePanel.SetActive(false);
    }
}
