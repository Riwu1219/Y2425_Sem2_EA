using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerManager : MonoBehaviour
{
    public static PlatformerManager instance;

    [SerializeField]
    [Header("-GetObject-")]
    private GameObject bubble;
    public GameObject goalPrefab;

    [Header("|| <STATUS> ||")]
    private int Count = 0;
    public List<GameObject> level;
    public bool isPlatformerEnd;

    [Header("|| <CONFIG> ||")]
    public GameObject bubblePrefab;
    public Transform spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Instantiate(level[Count]);
        LevelRestart(); 
    }

    private void FixedUpdate()
    {
        goalPrefab = GameObject.FindGameObjectWithTag("Finish");

        if (GameObject.FindGameObjectWithTag("Respawn") != null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        }

        if (GameObject.FindGameObjectWithTag("Finish") != null)
        {
            goalPrefab.transform.position = GameObject.FindGameObjectWithTag("Goal").transform.position;
        }


        if (GameObject.FindGameObjectWithTag("Bubble") == null)
        {
            Instantiate(bubblePrefab, spawnPoint.transform.position, Quaternion.identity);
        }
        
    }

    //Reset level included(bubble location, spawn goal)
    public void LevelRestart()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;

        if (GameObject.FindGameObjectWithTag("Bubble") == null)
        {
            Instantiate(bubblePrefab, spawnPoint);
        }

        Instantiate(goalPrefab, GameObject.FindGameObjectWithTag("Goal").transform.position, Quaternion.identity);
        Destroy(GameObject.FindGameObjectWithTag("Bubble"));
    }

    //Call by GoalScript
    public void LevelManager()
    {
        if (Count < level.Count)
        {
            Count++;
            Destroy(GameObject.FindGameObjectWithTag("LevelObject"));
            Destroy(GameObject.FindGameObjectWithTag("Goal")); //confirm detele to avoid bug

            Instantiate(level[Count]);

            LevelRestart();
        }
        else
        {
            isPlatformerEnd = true;
        }

    }

    
}
