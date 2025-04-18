using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bubbleMovement : MonoBehaviour
{
    [Header("|| <CONFIG> ||")]
    public float moveForce = 1f;
    public float moveHeightOffset = 1f;
    public float minMagnitude = 0.5f;
    public float maxMagnitude = 700;

    [Header("|| <STATUS> ||")]
    public bool Canceled = false;
    public bool canMove = true;

    [Header("|| <SCRIPT> ||")]
    public ObjectLocator objLocator;

    private Vector3 mousePosition;
    private Vector3 bubbleLocationOnScreen;

    private float x = 0, y = 0;
    private Rigidbody rb;
    private float curMagnitude;
    private Transform bubbleTrans;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bubbleTrans = GetComponent<Transform>();
        //animator = GetComponent<Animator>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moveable_Surface"))
        {
            canMove = true;
        }
        else
        {
            //animator.Play("Dead");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moveable_Surface"))
        {
            canMove = false;
        }
    }

    void Update()
    {
        ApplyForce();
    }

    //Used to calculate force and add force on bubble movement
    void ApplyForce()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition; //Get mouse onScreenPosition
            bubbleLocationOnScreen = objLocator.GetTargetLocationOnScreen(bubbleTrans); //Get bubble transform on screen

            //Calculate
            curMagnitude = Mathf.Sqrt(Mathf.Pow(mousePosition.x - bubbleLocationOnScreen.x, 2) + Mathf.Pow(mousePosition.y - bubbleLocationOnScreen.y, 2));
            Debug.Log(curMagnitude);
            x = mousePosition.x - bubbleLocationOnScreen.x;
            y = mousePosition.y - bubbleLocationOnScreen.y;

            //Allow user to cancel movement if the magnitude < than configurated value
            if (curMagnitude < minMagnitude)
            {
                Canceled = true;
            }
            else
            {
                Canceled = false;
            }

        }



        if (Input.GetMouseButtonUp(0) && canMove && !Canceled)
        {
            Vector3 force = new Vector3(x, y, 0);

            if (curMagnitude > maxMagnitude)
            {
                force = force.normalized * maxMagnitude;
            }
            else
            {
                //Magnitude * Adjustment Force
                x = x * moveForce;
                y = y * moveForce + moveHeightOffset;

                force = new Vector3(x, y, 0);
            }

            rb.AddForce(force);
            canMove = false;
            Debug.Log("Moved");
        }
    }

    //Used by Animation
    public void DeadVFX()
    {

    }
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
