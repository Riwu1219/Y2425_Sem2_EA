using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public static SpawnKey instance;

    public GameObject Key;
    public GameObject DollOnTableOBJ;
    public bool DollInBox = false;
    public bool FinishCleanRoom = false;
    public int GarbageInBin = 0;

    public DialogueManager dialogueManager; 

    private void Start()
    {
        instance = this;
        if (dialogueManager != null)
        {
            dialogueManager.ShowFirstDialogue(); //Call the first dialogue at the start
        }
    }

    public void ShowKey()
    {
        if (DollInBox && GarbageInBin == 15)
        {
            Key.SetActive(true);
        }
    }

    public void KeyActivate()
    {
        Key.SetActive(false);
        FinishCleanRoom = true;
        dialogueManager.ShowSecondDialogue(); //CALL THE SECOND DIALOGUE WHEM THE KEY IS ACTIVATED
    }


    public void KeyDestrory()
        {
            Key.SetActive(false);
            FinishCleanRoom = true;
        }
}

