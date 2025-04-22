using UnityEngine;

public class PortalOut : MonoBehaviour
{
    public Transform targetPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble"))
        {
            bubblePhysics bubblePhysicsScript = other.GetComponent<bubblePhysics>();
            if (bubblePhysicsScript != null)
            {
                bubblePhysicsScript.enabled = false;

                other.transform.position = targetPos.position;

            }
            else
            {
                  other.transform.position = targetPos.position;
            }
        }
    }
}