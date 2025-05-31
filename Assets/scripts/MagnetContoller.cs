using UnityEngine;

public class MagnetController : MonoBehaviour
{
    public Transform player;
    public float attractionRadius = 100f;
    public float pullSpeed = 150f;

    public GameObject magnetObject;

    private bool magnetAvailable = false;
    private bool magnetActive = false;
    private bool wasNight = false; // Track night-to-day transition

    void Start()
    {
        if (magnetObject != null)
        {
            magnetObject.SetActive(false);
        }
    }

    void Update()
    {
        // Detect transition from night to day
        if (wasNight && !GameSta.isNight)
        {
            DeactivateMagnetAfterNight();
        }

        // Update tracking
        wasNight = GameSta.isNight;

        // When the magnet becomes available
        if (DayNightCycle.spawnMagnetNow)
        {
            DayNightCycle.spawnMagnetNow = false;
            ShowMagnetChoicePanel();
            magnetAvailable = true;
        }

        // Player activates magnet manually with 'M' at night
        if (GameSta.isNight && magnetAvailable && !magnetActive && Input.GetKeyDown(KeyCode.M))
        {
            ActivateMagnet();
        }

        // Active magnet behavior
        if (magnetActive)
        {
            AttractTreasures();
        }
    }

    void AttractTreasures()
    {
        Collider2D[] treasures = Physics2D.OverlapCircleAll(player.position, attractionRadius);

        foreach (var t in treasures)
        {
            if (t.CompareTag("Treasure"))
            {
                t.transform.position = Vector2.MoveTowards(
                    t.transform.position,
                    player.position,
                    pullSpeed * Time.deltaTime
                );

                if (Vector2.Distance(t.transform.position, player.position) < 0.2f)
                {
                    TreasureManager.instance.ChangeTreasures(5);
                    Destroy(t.gameObject);
                }
            }
        }
    }

    public void ActivateMagnet()
    {
        magnetActive = true;
        magnetAvailable = true;
        if (magnetObject != null)
        {
            magnetObject.SetActive(true);
        }
    }

    public void SaveMagnet()
    {
        magnetActive = false;
        magnetAvailable = true;
        if (magnetObject != null)
        {
            magnetObject.SetActive(false); // Keep it hidden
        }
    }

    private void DeactivateMagnetAfterNight()
    {
        magnetActive = false;
        if (magnetObject != null)
        {
            magnetObject.SetActive(false);
        }
    }

    void ShowMagnetChoicePanel()
    {
        UIMagnet.Instance.ShowMagnetPanel();
    }
}
