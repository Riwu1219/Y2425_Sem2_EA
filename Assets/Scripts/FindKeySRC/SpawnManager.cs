using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Garbage;
    public float SpawnTimer;
    public Transform[] SpawnPoint;
    public int SpawnCount;
    void Start()
    {
        InvokeRepeating("Spawn", 2, SpawnTimer);
    }

    void Spawn()
    {
        if (SpawnKey.instance.StartGame && SpawnKey.instance.GarbageInBin < 5 && SpawnCount < 5)
        {
            int spwanpointIndex = Random.Range(0, SpawnPoint.Length);
            int SpawnEnemyIndex = Random.Range(0, Garbage.Length);
            Instantiate(Garbage[SpawnEnemyIndex], SpawnPoint[spwanpointIndex].position, SpawnPoint[spwanpointIndex].rotation);
            SpawnCount++;
        }
    }
}
