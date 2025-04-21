using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float respawnDelay = 0.3f;
    public Vector3 minSpawnPosition;
    public Vector3 maxSpawnPosition;
    public Text killCountText;

    private int killCount = 0;
    private bool canRespawn = true;

    void Start()
    {
        UpdateKillCountUI();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name); // <<<<< should will show the name of the object hit
                if (hit.collider != null && hit.collider.CompareTag("Bubble"))
                {

                    PlaySoundOnDestroy soundScript = hit.collider.GetComponent<PlaySoundOnDestroy>(); // call the script that plays the sound
                    if (soundScript != null)
                    {
                        soundScript.PlayDeadSound(); // play the sound
                    }

                    Destroy(hit.collider.gameObject);
                    killCount++;
                    UpdateKillCountUI();

                    if (killCount < 20 && canRespawn) // <<<<<<<<<<< (Win condititon >=10)
                    {
                        StartCoroutine(RespawnBubble());
                    }
                    else
                    {
                        canRespawn = false; // STOP RESPAWNING
                    }
                }
            }
        }
    }

    IEnumerator RespawnBubble() //wait for a few seconds before respawning the bubble
    {
        yield return new WaitForSeconds(respawnDelay);

        Vector3 randomPosition = new Vector3(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y),
            Random.Range(minSpawnPosition.z, maxSpawnPosition.z)
        );

        Instantiate(bubblePrefab, randomPosition, Quaternion.identity);
    }

    void UpdateKillCountUI()    
    {
        killCountText.text = "x" + killCount; // Update the UI text
    }
}