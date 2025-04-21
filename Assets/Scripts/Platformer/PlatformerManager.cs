using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerManager : MonoBehaviour
{
    public static PlatformerManager instance;

    [SerializeField]
    [Header("-GetObject-")]
    private GameObject bubble;
    private GameObject goal;

    [Header("|| <STATUS> ||")]
    public int levelCount = 0;
    public List<GameObject> level = new List<GameObject>();

    [Header("|| <CONFIG> ||")]
    public GameObject bubblePrefab;
    public Transform spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Bubble") == null)
        {
            Instantiate(bubblePrefab, spawnPoint);
        }

        if (goal == null)
        {
            goal = GameObject.FindGameObjectWithTag("Goal") ;
        }

    }

    //Call by GoalScript
    public void LevelManager()
    {
        if (levelCount < level.Count)
        {
            Destroy(level[levelCount]);
            levelCount++;
            Instantiate(level[levelCount]);
        }
        
    }

}
