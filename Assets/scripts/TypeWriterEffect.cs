using TMPro;
using UnityEngine;
using System.Collections;

public class TypeWriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [TextArea]
    public string fullText = "Now You’ve arrived at your first destination in the quest for treasure. It is said that those who seek the eagle’s treasure are destroyed immediately. Avoid them and collect as much treasure as you can.";
    public float delay = 0.05f;
    public GameObject startButton;
    public float startDelay = 0f;

    public AudioSource audioSource;
    public AudioClip typingClip;
    public float soundDelay = 0.2f;

    private bool isTyping = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(startButton!=null)
        {
            startButton.SetActive(false);
        }

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";
        yield return new WaitForSeconds(startDelay);

        isTyping = true;
        foreach (char c in fullText)
        {
            textComponent.text += c;

            if (typingClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(typingClip);
                yield return new WaitForSeconds(soundDelay);
            }

            
            yield return new WaitForSeconds(0.05f);

        }
        textComponent.text = fullText;
        isTyping = false;

        if (startButton != null)
        {
            startButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTyping&&Input.anyKeyDown)
        {
            StopAllCoroutines();
            textComponent.text = fullText;
            isTyping = false;
            if(startButton != null)
            {
                startButton.SetActive(true);
            }
        }
    }
}
