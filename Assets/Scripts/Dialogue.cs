 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty; // Clear the text at the start
        StartDialogue();
    }

    void Update()
    {

    }


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        Nextline(); // go to the next line after typing the current one
    }

    void Nextline()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty; // Clear the text for the next line
            StartCoroutine(TypeLine());
        }
        else
        {
           gameObject.SetActive(false); // Deactivate the dialogue box when done
        }
    }

}
