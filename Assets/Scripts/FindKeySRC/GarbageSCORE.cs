using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GarbageSCORE : MonoBehaviour
{
    public static GarbageSCORE instance;
    public TMP_Text GarbageInBinNumber;
    public GameObject GarbageInBinNumberObj;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        ScoreUpdate(SpawnKey.instance.GarbageInBin);
    }

    public void ScoreUpdate(int num) 
    {
        GarbageInBinNumber.text = "PLayer Score:" + num + "/5";
        if (SpawnKey.instance.StartGame)
        { 
            GarbageInBinNumberObj.SetActive(true); 
        }
    }
}
