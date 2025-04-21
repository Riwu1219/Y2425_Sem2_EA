using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerManager : MonoBehaviour
{
    public static PlatformerManager instance;

    [SerializeField]
    [Header("-GetObject-")]
    private GameObject bubble;
    public GameObject goal;

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
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        if (GameObject.FindGameObjectWithTag("Bubble") == null)
        {
            Instantiate(bubblePrefab, spawnPoint.transform.position, Quaternion.identity);
        }

        if (goal == null)
        {
            goal = GameObject.FindGameObjectWithTag("Goal") ;
        }

    }

    //Reset level included(bubble location, spawn goal)
    public void LevelRestart()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;

        if (GameObject.FindGameObjectWithTag("Bubble") == null)
        {
            Instantiate(bubblePrefab, GameObject.FindGameObjectWithTag("Respawn").transform.position, Quaternion.identity);
        }

        Instantiate(goal, GameObject.FindGameObjectWithTag("Goal").transform.position, Quaternion.identity);
        Destroy(GameObject.FindGameObjectWithTag("Bubble"));
    }

    //Call by GoalScript
    public void LevelManager()
    {
        if (Count < level.Count)
        {
            Count++;
            Destroy(GameObject.FindGameObjectWithTag("LevelObject"));
            
            Instantiate(level[Count]);

            LevelRestart();
        }
        else
        {
            isPlatformerEnd = true;
        }

    }

    
}
