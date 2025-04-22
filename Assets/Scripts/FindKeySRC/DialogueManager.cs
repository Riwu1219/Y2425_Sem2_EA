using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogueBox;  
    public Dialogue dialogueBox2; 

    private void Start()
    {
        ShowFirstDialogue(); 
    }

    public void ShowFirstDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueBox.gameObject.SetActive(true);
            dialogueBox.StartDialogue();
        }
        else
        {
            Debug.LogError("DialogueBox not assigned in the inspector!");
        }
    }

    public void ShowSecondDialogue()
    {
        if (dialogueBox2 != null)
        {
            dialogueBox2.gameObject.SetActive(true);
            dialogueBox2.StartDialogue();
        }
        else
        {
            Debug.LogError("DialogueBox2 not assigned in the inspector!");
        }
    }
}