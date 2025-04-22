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

    public Dialogue dialogueBox1; 
    public Dialogue dialogueBox2; 
    public Dialogue dialogueBox3;
    public Dialogue dialogueBox4;


    public AudioSource shootingSound;

    private int killCount = 0;
    private bool canRespawn = true;

    void Start()
    {
        UpdateKillCountUI();
        // activate the first dialogue box
        dialogueBox1.gameObject.SetActive(true);
        dialogueBox1.StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootingSound.Play(); // play shooting sound


            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider != null && hit.collider.CompareTag("Bubble"))
                {
                    PlaySoundOnDestroy soundScript = hit.collider.GetComponent<PlaySoundOnDestroy>();
                    if (soundScript != null)
                    {
                        soundScript.PlayDeadSound();
                    }

                    Destroy(hit.collider.gameObject);
                    killCount++;
                    UpdateKillCountUI();

                    // CHECK FOR DIALOGUE HERE  
                    CheckForDialogue();

                    if (killCount < 30 && canRespawn)
                    {
                        StartCoroutine(RespawnBubble());
                    }
                    else
                    {
                        canRespawn = false;
                    }
                }
            }
        }
    }

    IEnumerator RespawnBubble()
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
        killCountText.text = "x" + killCount;
    }

    void CheckForDialogue()
    {
        if (killCount == 10 && !dialogueBox2.gameObject.activeSelf)
        {
            dialogueBox2.gameObject.SetActive(true); // activate the second dialogue box
            dialogueBox2.StartDialogue();
        }
        else if (killCount == 20 && !dialogueBox3.gameObject.activeSelf)
        {
            dialogueBox3.gameObject.SetActive(true); // activate the third dialogue box
            dialogueBox3.StartDialogue();
        }
        else if (killCount == 30 && !dialogueBox4.gameObject.activeSelf)
        {
            dialogueBox4.gameObject.SetActive(true); // activate the fourth dialogue box
            dialogueBox4.StartDialogue();
        }
    }
}