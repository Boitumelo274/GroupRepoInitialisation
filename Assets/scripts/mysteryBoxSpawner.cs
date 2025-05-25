using UnityEngine;
using System.Collections;

public class MysteryBoxController : MonoBehaviour
{
    public GameObject mysteryBox; // Drag the scene object here
    public float[] laneXPositions = new float[] { -3f, 0f, 3f }; // Your lane X positions
    public float spawnY = 0f; // Keep your current Y

    public float delayTime = 25f;

    void Start()
    {
        StartCoroutine(ShowAndMoveMysteryBox());
    }

    IEnumerator ShowAndMoveMysteryBox()
    {
        yield return new WaitForSeconds(delayTime);

        int laneIndex = Random.Range(0, laneXPositions.Length);
        float spawnX = laneXPositions[laneIndex];

        Vector3 newPos = new Vector3(spawnX, spawnY, 0f);
        mysteryBox.transform.position = newPos;
        mysteryBox.SetActive(true);
    }
}
