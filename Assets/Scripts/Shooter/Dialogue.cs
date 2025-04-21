using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    [Header("|| <TextArea> ||")]
    public TextMeshProUGUI dialog;

    [Header("|| <TextLines> ||")]
    public string[] lines;

    [Header("|| <CONFIG> ||")]
    public float textSpeed;
    public float spaceSpeed;
    public float lineDelay;
    public bool isDelay;

    private int index;


    void Start()
    {
        dialog.text = string.Empty; // Clear the text at the start
        StartDialogue();
    }

    void Update()
    {

    }


    void StartDialogue()
    {
        //Set start text line to first line(0) in list
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if (c == ' ')
            {
                yield return new WaitForSeconds(spaceSpeed);
            }

            dialog.text += c;
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
            index++;
            dialog.text = string.Empty; // Clear the text for the next line
            StartCoroutine(TypeLine());
        }
        else
        {
           gameObject.SetActive(false); // Deactivate the dialogue box when done
        }
    }

}
