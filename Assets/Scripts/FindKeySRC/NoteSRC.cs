using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSRC : MonoBehaviour
{
    public GameObject crosshair1, crosshair2 , note;
    public bool interactable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
        }
    }
    void Update()
    {
        if (interactable) 
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                note.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                crosshair1.SetActive(false);
                crosshair2.SetActive(true);
                note.SetActive(false);
            }
        }
    }
}
