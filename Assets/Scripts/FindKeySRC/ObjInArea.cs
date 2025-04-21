using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Doll" && this.gameObject.name == "Box_For_Doll" && SpawnKey.instance.FinishCleanRoom == false) 
        {
                SpawnKey.instance.DollInBox = true;
                SpawnKey.instance.ShowKey();
                SpawnKey.instance.DollOnTableOBJ.SetActive(true);
                Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Garbage" && this.gameObject.name == "Bin" && SpawnKey.instance.FinishCleanRoom == false)
        {
                SpawnKey.instance.GarbageInBin += 1;
                SpawnKey.instance.ShowKey();
                Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Key" && this.gameObject.name == "Door" && SpawnKey.instance.FinishCleanRoom == false)
        {
           Destroy(this.gameObject);
           Destroy(this);
           SpawnKey.instance.KeyDestrory();

        }
    }
}

