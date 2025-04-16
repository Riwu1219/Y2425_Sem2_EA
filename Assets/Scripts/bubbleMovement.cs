using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bubbleMovement : MonoBehaviour
{
    private float x = 0, y = 0;
    private Rigidbody rb;
    private float magnitude;

    public float minMagnitude = 0.5f;
    public Transform bubbleTrans;
    protected Transform mouseTrans;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bubbleTrans = GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    //Used to calculate force and add force on bubble movement
    void ForceCaculation()
    {
        bool Canceled = false;
        if (Input.GetMouseButtonDown(0))
        {
            //Calculate 

            //Allow user to cancel movement if the magnitude < than configurated value
            if (magnitude < minMagnitude)
            {
                Canceled = true;
            }
        }
        if (Input.GetMouseButtonUp(0) && !Canceled)
        {
            rb.AddForce(x, y, 0);
        }
        
    }
}
