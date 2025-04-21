using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Garbage;
    public float SpawnTimer;
    public Transform[] SpawnPoint;
    public int SpawnCount = 0;
    void Start()
    {
        InvokeRepeating("Spawn", 2, SpawnTimer);
    }

    void Spawn()
    {
        if (SpawnKey.instance.FinishCleanRoom == false && SpawnKey.instance.GarbageInBin < 15 && SpawnCount < 15)
        {
            int spwanpointIndex = Random.Range(0, SpawnPoint.Length);
            int SpawnEnemyIndex = Random.Range(0, Garbage.Length);
            Instantiate(Garbage[SpawnEnemyIndex], SpawnPoint[spwanpointIndex].position, SpawnPoint[spwanpointIndex].rotation);
            SpawnCount++;
        }
    }
}
