//
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

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
    public bool isDead = false;
    public bool fallOut = false;


    [Header("|| <Component> ||")]
    public ObjectLocator objLocator;
    public AudioSource landJumpSound;
    public AudioSource destroySound;

    private Vector3 mousePosition;
    private Vector3 bubbleLocationOnScreen;

    private float x = 0, y = 0;
    private Rigidbody rb;
    private float curMagnitude;
    private Transform bubbleTrans;
    private Animator animator;

    private ParticleSystem DeadVFX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bubbleTrans = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        objLocator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectLocator>();
        DeadVFX = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moveable_Surface"))
        {
            PlayLandJumpSound();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moveable_Surface"))
        {
            canMove = true;
        }
        else
        {
            Dead();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moveable_Surface"))
        {
            PlayLandJumpSound();
            canMove = false;
        }
    }

    void Update()
    {
        if (!isDead)
        {
            checkLocation();
            ApplyForce();
        }

    }

    //Used to calculate force and add force on bubble movement
    void ApplyForce()
    {
        Vector3 force = new Vector3(x, y, 0);

        if (Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButton(0))
        {
            bubbleTrans = GetComponent<Transform>();
            mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition); //Get mouse onScreenPosition
            bubbleLocationOnScreen = objLocator.GetTargetLocationOnScreen(bubbleTrans); //Get bubble transform on screen

            //Calculate
            curMagnitude = Mathf.Sqrt(Mathf.Pow(mousePosition.x - bubbleLocationOnScreen.x, 2) + Mathf.Pow(mousePosition.y - bubbleLocationOnScreen.y, 2));
            //Debug.Log(curMagnitude);
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
            if (curMagnitude > maxMagnitude)
            {
                //Debug.Log(force);
                force = force.normalized * (maxMagnitude * 2);
                //Debug.Log(force + " normalized");
                force = new Vector3(force.x * moveForce / 2, force.y * moveForce / 2, 0);
                //Debug.Log(force + " final");
            }
            else
            {
                //Magnitude * Adjustment Force
                x = x * moveForce;
                y = y * moveForce + moveHeightOffset;
                force = new Vector3(x, y, 0);
                //Debug.Log(force + " final < max");
            }

            rb.AddForce(force);
            canMove = false;
            //Debug.Log("Moved");
        }
    }

    private void checkLocation()
    {
        if (gameObject.transform.position.y <= -2 && fallOut == false)
        {
            fallOut = true;
            rb.isKinematic = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            animator.Play("Dead");
            Invoke("SelfDestroy", 1);
        }
    }

    private void Dead()
    {
        isDead = true;
        rb.isKinematic = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        animator.Play("Dead");
    }


    public void PlayLandJumpSound()
    {
        landJumpSound.pitch = Random.Range(1f, 1.2f);
        landJumpSound.Play();
    }

    //Used by Animation
    public void PlayDeadVFX()
    {
        DeadVFX.Play();
    }

    public void PlayDestroySound()
    {
        destroySound.Play();
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }


}
