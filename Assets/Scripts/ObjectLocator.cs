using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectLocator : MonoBehaviour
{
    public GameObject targetObj; // The game object to track on Screen
    private Transform target;
    public Camera currentCamera;

    void Start()
    {

    }

    void Update()
    {
        GetTargetLocationOnScreen(target);
    }

    public Vector3 GetTargetLocationOnScreen(Transform target)
    {
        target = targetObj.transform;

        if (currentCamera != null)
        {
            Vector3 targetPosition = target.position;
            
            //Vector3 viewportPosition = currentCamera.WorldToViewportPoint(targetPosition); 
            //Debug.Log("Viewport Position: " + viewportPosition);

            Vector3 screenPosition = currentCamera.WorldToScreenPoint(targetPosition); //choosed cause float easiler to calculate
            Debug.Log("Screen Position: " + screenPosition);

            return (screenPosition);
        } 
        else
        {
            return (new Vector3(0,0,0));
        }
    }
}
