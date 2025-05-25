using UnityEngine;


public class mysteryBox : MonoBehaviour
{
    public  GameManager2D gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.TriggerMysteryBox();
            gameObject.SetActive(false); // deactivate box
        }
    }
}
