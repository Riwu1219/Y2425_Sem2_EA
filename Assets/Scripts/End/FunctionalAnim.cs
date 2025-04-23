
using UnityEngine;

public class FunctionalAnim : MonoBehaviour
{
    public Animator door;
    public GameObject FirstDialog;

    public void OpenDoor()
    {
        door.Play("Open");
    }

    public void StartDialog()
    {
        if (FirstDialog != null)
        {
            FirstDialog.GetComponent<Dialogue>().StartDialogue();
        }
        
    }
}
