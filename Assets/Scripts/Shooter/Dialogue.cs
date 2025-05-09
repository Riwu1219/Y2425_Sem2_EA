﻿using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    [Header("|| <TextArea> ||")]
    public TextMeshProUGUI dialog;

    [Header("|| <TextLines> ||")]
    public string[] lines;

    [Header("|| <CONFIG> ||")]
    public float textSpeed = 0.06f;
    public float spaceSpeed = 0.02f;
    public float lineDelay = 2f;
    public bool isDelay;

    [Header("|| <Event> ||")]
    public bool EventAfterEnd;
    public bool triggerEvent = false;
    public GameObject NextDialogue; //If have can connect different dialog script together

    private int index;
    private bool isDialogueActive = false;

    void Start()
    {
        if (dialog.text != null)
        {
            dialog.text = string.Empty;
        }
        
    }

    public void StartDialogue()
    {
        if (isDialogueActive) return;

        isDialogueActive = true;
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void StartFirstDialogue()
    {
        StartDialogue(); //Start the first dialogue
    }

    IEnumerator TypeLine()
    {
        dialog.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            if (c == ' ')
            {
                yield return new WaitForSeconds(spaceSpeed);
            }

            dialog.text += c; // add the character to the text
            yield return new WaitForSeconds(textSpeed);
        }

        if (isDelay)
        {
            StartCoroutine(LineDelay());
        }
        else
        {
            Nextline();
        }
    }

    IEnumerator LineDelay()
    {
        yield return new WaitForSeconds(lineDelay);
        Nextline();
    }

    void Nextline()
    {
        if (index < lines.Length - 1)
        {
            index++; // add 1 to the index
            dialog.text = string.Empty; // clear the text
            StartCoroutine(TypeLine());
        }
        else if (EventAfterEnd)
        {

            if (NextDialogue != null)
            {
                NextDialogue.GetComponent<Dialogue>().StartFirstDialogue();
            }
            
            triggerEvent = true;
        }
        else
        {
            isDialogueActive = false;
            gameObject.SetActive(false);  
        }
    }
}