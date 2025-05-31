using UnityEngine;

public class UIMagnet : MonoBehaviour
{
    public static UIMagnet Instance;

    public GameObject magnetPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMagnetPanel()
    {
        magnetPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UseMagnetNow()
    {
        magnetPanel.SetActive(false);
        FindObjectOfType<MagnetController>().ActivateMagnet();
        Time.timeScale = 1f;
    }

    public void SaveMagnetForLater()
    {
        magnetPanel.SetActive(false);
        FindObjectOfType<MagnetController>().SaveMagnet();
        Time.timeScale = 1f;
        // Magnet stays available, just not activated yet
    }
}
