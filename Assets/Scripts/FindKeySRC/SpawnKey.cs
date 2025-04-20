using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public static SpawnKey instance ;

    public GameObject Key;
    public bool DollInBox = false ;
    public bool GarbageInBin = false;

    private void Start()
    {
        instance = this ;
    }
    private void Update()
    {
        if (DollInBox == true && GarbageInBin == true) 
        {
            Key.SetActive(true);
        }
    }
}
