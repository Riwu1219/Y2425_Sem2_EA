using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bubbleMovement : MonoBehaviour
{
    private float x = 0, y = 0;
    private Rigidbody rb;
    private float magnitude;
    private Transform bubbleTrans;

    public float moveForce = 1f;
    public float minMagnitude = 0.5f;
    protected Transform mouseTrans;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bubbleTrans = GetComponent<Transform>();
    }

    void Update()
    {
        ForceCaculation();
    }

    //Used to calculate force and add force on bubble movement
    void ForceCaculation()
    {
        bool Canceled = false;
        if (Input.GetMouseButtonDown(0))
        {
            //Calculate 

            //Magnitude * Adjustment Force
            x = x * moveForce;
            y = y * moveForce;

            //Allow user to cancel movement if the magnitude < than configurated value
            if (magnitude < minMagnitude)
            {
                Canceled = true;
            }
        }

        

        if (Input.GetMouseButtonUp(0) && !Canceled)
        {
            Debug.Log("Moved");
            rb.AddForce(10, 100, 0);
        }
        
    }
}
