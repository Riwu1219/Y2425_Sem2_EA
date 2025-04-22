using System.Collections;
using UnityEngine;

public class AimLabManager : MonoBehaviour
{
    public float startGameDelay; // game start delay
    public GameObject bubblePrefab; 

    private Vector3 bubblePosition = new Vector3(0, 2, -2.73f); // Bubble spawn position

    IEnumerator Start()
    {
        yield return new WaitForSeconds(startGameDelay); 


        Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);
    }
}