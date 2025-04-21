using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlatformerManager.instance.LevelManager();
        Destroy(gameObject);
    }

}
