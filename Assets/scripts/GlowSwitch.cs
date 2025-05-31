using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glow : MonoBehaviour
{
    private Light2D treasureLight;

    void Start()
    {
        treasureLight = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        if (treasureLight != null)
        {
            treasureLight.enabled = GameSta.isNight;
        }
    }
}
