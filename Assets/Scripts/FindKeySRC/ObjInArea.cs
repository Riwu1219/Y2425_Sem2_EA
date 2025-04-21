using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Doll" && this.gameObject.name == "Box_For_Doll") 
        {
                SpawnKey.instance.DollInBox = true;
        }
        if (other.gameObject.name == "Garbage" && this.gameObject.name == "Bin")
        {
                SpawnKey.instance.GarbageInBin = true;
        }
        if (other.gameObject.name == "Key" && this.gameObject.name == "Door")
        {
           Destroy(this.gameObject);

        }
    }
}

