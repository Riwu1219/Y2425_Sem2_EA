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

    public DialogueManager dialogueManager; // 引用到 DialogueManager

    private void Start()
    {
        instance = this;
        if (dialogueManager != null)
        {
            dialogueManager.ShowFirstDialogue(); // 游戏开始时显示第一个对话框
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
        dialogueManager.ShowSecondDialogue(); // 激活钥匙后显示第二个对话框
    }


    public void KeyDestrory()
        {
            Key.SetActive(false);
            FinishCleanRoom = true;
        }
}

