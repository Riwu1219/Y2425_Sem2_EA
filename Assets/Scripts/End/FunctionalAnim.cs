using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalAnim : MonoBehaviour
{
    public Animator door;

    public void OpenDoor()
    {
        door.Play("Open");
    }
}
