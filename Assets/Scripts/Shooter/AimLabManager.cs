using System.Collections;
using UnityEngine;

public class AimLabManager : MonoBehaviour
{
    public float startGameDelay; 
    public GameObject bubblePrefab;

    private Vector3 bubblePosition = new Vector3(0, 2, -2.73f);
    private bool gameStarted = false;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(startGameDelay);
        StartGame();
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);
            gameStarted = true;
        }
    }


    public void ResetGame()
    {
        gameStarted = false; 
    }
}