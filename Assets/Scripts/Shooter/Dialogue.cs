using System.Collections;
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
    private bool isDialogueActive = false; 

    void Start()
    {
        dialog.text = string.Empty; 
        
    }

    public void StartDialogue()
    {
        if (isDialogueActive) return;

        isDialogueActive = true; 
        index = 0;
        StartCoroutine(TypeLine()); 
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

            dialog.text += c; // add character to text 
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
            index++; // add 1 to index
            dialog.text = string.Empty; //clear text
            StartCoroutine(TypeLine());
        }
        else
        {
            isDialogueActive = false;
            gameObject.SetActive(false); 
        }
    }
}