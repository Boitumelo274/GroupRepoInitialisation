using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 15f;
    public float nightDuration = 10f;
    public float transitionDuration = 5f;

    private float timer = 0f;
    private enum Phase { Day, Transition, Night }
    private Phase currentPhase = Phase.Day;

    void Update()
    {
        timer += Time.deltaTime;

        switch (currentPhase)
        {
            case Phase.Day:
                if (timer >= dayDuration)
                    SwitchToPhase(Phase.Transition);
                break;

            case Phase.Transition:
                if (timer >= transitionDuration)
                    SwitchToPhase(Phase.Night);
                break;

            case Phase.Night:
                if (timer >= nightDuration)
                    SwitchToPhase(Phase.Day);
                break;
        }
    }

    void SwitchToPhase(Phase newPhase)
    {
        currentPhase = newPhase;
        timer = 0f;

      
        GameSta.isNight = (newPhase == Phase.Night);
    }
}
