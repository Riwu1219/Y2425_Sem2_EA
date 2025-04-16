using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollowing : MonoBehaviour
{
    public bool isFollowing = true;

    public GameObject target;
    public float cameraOffsetY;
    public float cameraSpeed;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Bubble");
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + cameraOffsetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed);
        } 
        else
        {
            target = GameObject.FindGameObjectWithTag("Bubble");
        }
            
    }
}
