using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class floorBubbleOnDetect : MonoBehaviour
{
    public GameObject Bubble;

    void Start()
    {
        //Set DefaultScale of Bubble
        Vector3 DefaultScale = Bubble.transform.localScale;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Bubble)
        {

           
        }
        
    }

    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject == Bubble)
        {

            
        }

    }
}
