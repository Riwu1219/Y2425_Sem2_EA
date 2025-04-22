using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOut : MonoBehaviour
{
    public Transform targetPos; //The position to teleport to, set in Unity 

    private void OnTriggerEnter(Collider other)
    {
        //Other "Bubble" object can transform
        if (other.CompareTag("Bubble"))
        {

            other.transform.position = targetPos.position;
        }
    }
}