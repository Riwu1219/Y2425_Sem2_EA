using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public static SpawnKey instance ;

    public GameObject Key;
    public GameObject DollOnTableOBJ;
    public bool DollInBox = false ;
    public bool FinishCleanRoom = false;
    public int GarbageInBin = 0;

    private void Start()
    {
        instance = this ;
    }
    public void ShowKey()
    {
        if (DollInBox == true && GarbageInBin == 15) 
        {
            Key.SetActive(true);
        }
    }

    public void KeyDestrory ()
    {
        Key.SetActive(false);
        FinishCleanRoom = true ;
    }
}
