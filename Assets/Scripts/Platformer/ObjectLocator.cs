using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectLocator : MonoBehaviour
{
    private GameObject targetObj; // The game object to track on Screen
    private Transform target;

    public string objectTag;
    public Camera currentCamera;

    void Start()
    {

    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag(objectTag) != null)
        {
            targetObj = GameObject.FindGameObjectWithTag(objectTag);
            target = GameObject.FindGameObjectWithTag(objectTag).transform;
            GetTargetLocationOnScreen(target);
        }
        
    }

    public Vector3 GetTargetLocationOnScreen(Transform target)
    {
        
        target = targetObj.transform;

        if (currentCamera != null)
        {
            Vector3 targetPosition = target.position;
            
            Vector3 viewportPosition = currentCamera.WorldToViewportPoint(targetPosition); //choosed cause float easiler to calculate
            //Debug.Log("Viewport Position: " + viewportPosition);

            //Vector3 screenPosition = currentCamera.WorldToScreenPoint(targetPosition); 
            //Debug.Log("Screen Position: " + screenPosition);

            return (viewportPosition);
        } 
        else
        {
            return (new Vector3(0,0,0));
        }
    }
}
