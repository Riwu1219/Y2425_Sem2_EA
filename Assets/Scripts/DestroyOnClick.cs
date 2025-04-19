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
                    Destroy(hit.collider.gameObject);
                    killCount++;
                    UpdateKillCountUI();
                    StartCoroutine(RespawnBubble());
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