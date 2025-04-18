using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerManager : MonoBehaviour
{
    [SerializeField]
    [Header("GetObject")]
    private GameObject bubble;

    [Header("Setting")]
    public GameObject bubblePrefab;
    public Transform spawnPoint;

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Bubble") == null)
        {
            Instantiate(bubblePrefab, spawnPoint);
        }
    }
}
