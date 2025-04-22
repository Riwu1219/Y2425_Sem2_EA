using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PortalOut : MonoBehaviour
{
    public GameObject TeleportTarget;
    public bool isCoolDown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble") && !isCoolDown)
        {
            bubblePhysics bubblePhysicsScript = other.GetComponent<bubblePhysics>();
            if (bubblePhysicsScript != null)
            {
                isCoolDown = true;
                bubblePhysicsScript.isTeleport = true;
                TeleportTarget.GetComponent<PortalOut>().isCoolDown = true;
                other.transform.position = TeleportTarget.transform.position;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isCoolDown = false;
    }
}