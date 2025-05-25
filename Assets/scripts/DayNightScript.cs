using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNightCycleSimple : MonoBehaviour
{
    public Volume ppv;                    // Post-processing volume to fade night in/out
    public GameObject[] lights;          // Lights to activate at night
    public SpriteRenderer[] stars;       // Stars to show at night

    public float transitionTime = 2f;     // Time to fade day/night
    public float dayDuration = 15f;       // Total time to stay in day mode
    public float nightDuration = 5f;      // Total time to stay in night mode

    private bool isNight = false;

    void Start()
    {
        // Start in day mode
        ppv.weight = 0f;
        SetStarsAlpha(0f);
        ToggleLights(false);

        // Begin the cycle
        StartCoroutine(DayNightLoop());
    }

    IEnumerator DayNightLoop()
    {
        while (true)
        {
            if (!isNight)
            {
                yield return new WaitForSeconds(dayDuration);
                yield return StartCoroutine(FadeToNight());
                isNight = true;
            }
            else
            {
                yield return new WaitForSeconds(nightDuration);
                yield return StartCoroutine(FadeToDay());
                isNight = false;
            }
        }
    }

    IEnumerator FadeToNight()
    {
        float t = 0f;
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            float progress = t / transitionTime;
            ppv.weight = progress;
            SetStarsAlpha(progress);
            yield return null;
        }

        ppv.weight = 1f;
        SetStarsAlpha(1f);
        ToggleLights(true);
    }

    IEnumerator FadeToDay()
    {
        float t = 0f;
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            float progress = 1f - (t / transitionTime);
            ppv.weight = progress;
            SetStarsAlpha(progress);
            yield return null;
        }

        ppv.weight = 0f;
        SetStarsAlpha(0f);
        ToggleLights(false);
    }

    void ToggleLights(bool state)
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(state);
        }
    }

    void SetStarsAlpha(float alpha)
    {
        foreach (SpriteRenderer star in stars)
        {
            Color c = star.color;
            star.color = new Color(c.r, c.g, c.b, alpha);
        }
    }
}