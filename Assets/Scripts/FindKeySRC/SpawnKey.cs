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
    public bool StartGame = false;
    public int GarbageInBin = 0;
    public Animator Anim;
    public DialogueManager dialogueManager;
    public GoableChangeScence GoableChangeScence;
    private void Start()
    {
        instance = this;
        if (dialogueManager != null)
        {
            StartCoroutine(SpawnDelay());
        }
    }

    public void ShowKey()
    {
        if (DollInBox && GarbageInBin == 5)
        {
            Key.SetActive(true);
            dialogueManager.ShowSecondDialogue();
        }
    }
 /*   public void KeyActivate()
    {
        Key.SetActive(false);
        FinishCleanRoom = true;
        dialogueManager.ShowSecondDialogue(); //CALL THE SECOND DIALOGUE WHEM THE KEY IS ACTIVATED
    }
 */
    public void KeyDestrory()
        {
            Key.SetActive(false);
            Anim.SetTrigger("DoorOpen");
            FinishCleanRoom = true;
            StartCoroutine(Delay());
    }
    IEnumerator SpawnDelay()
    {
        dialogueManager.ShowFirstDialogue(); //Call the first dialogue at the start
        yield return new WaitForSeconds(15);
        StartGame = true;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
        StartGame = true;
        GoableChangeScence.KeyToPlatformer();
    }
}

