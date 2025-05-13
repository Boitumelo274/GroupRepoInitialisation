

using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int treasureValue = 10;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerInventory component from the player
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (transform.position.y == 0)
            {
                inventory.AddTreasure(treasureValue);
                Destroy(gameObject); // Remove the treasure after collecting
            }
        }
    }
}

