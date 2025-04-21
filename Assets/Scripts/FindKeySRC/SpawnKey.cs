using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public static SpawnKey instance ;

    public GameObject Key;
    public GameObject DollOnTableOBJ;
    public GameObject GarbageInBinOBJ;
    public bool DollInBox = false ;
    public bool GarbageInBin = false;
    public bool FinishCleanRoom = false ;

    private void Start()
    {
        instance = this ;
    }
    public void ShowKey()
    {
        if (DollInBox == true && GarbageInBin == true) 
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
