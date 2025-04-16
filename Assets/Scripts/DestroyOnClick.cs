using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float respawnDelay = 0.3f; //RespawnDelay time 

    // SpawnPosition
    public Vector3 minSpawnPosition;
    public Vector3 maxSpawnPosition;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 1000f)) //raycast detect distance
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name); //<<<<<<<  should will show the name of the object hit
                if (hit.collider != null && hit.collider.CompareTag("Bubble"))
                {
                    Destroy(hit.collider.gameObject);
                    StartCoroutine(RespawnBubble());
                }
            }
            else
            {
                Debug.Log("No hit detected.");
            }
        }
    }

    IEnumerator RespawnBubble()
    {
        // wait till the respawntime
        yield return new WaitForSeconds(respawnDelay);


        Vector3 randomPosition = new Vector3(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y),
            Random.Range(minSpawnPosition.z, maxSpawnPosition.z)
        );

        // Respawn
        Instantiate(bubblePrefab, randomPosition, Quaternion.identity);
    }
}   