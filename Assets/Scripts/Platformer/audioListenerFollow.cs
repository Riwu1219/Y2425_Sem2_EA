using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioListenerFollow : MonoBehaviour
{
    void Update()
    {
        GameObject bubble = GameObject.FindGameObjectWithTag("Bubble");

        if (bubble != null)
        {
            gameObject.transform.position = bubble.transform.position;
        }
        
    }
}
