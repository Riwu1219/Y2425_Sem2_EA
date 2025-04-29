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
    public Text timerText;

    public Dialogue dialogueBox;
    public Dialogue dialogueBox2;
    public Dialogue dialogueBox3;
    public Dialogue dialogueBox4;

    private int killCount = 0;
    private bool canRespawn = true;
    private float timer = 3f;
    private bool timerRunning = false;
    private bool bubbleSpawned = false;

    void Start()
    {
        UpdateKillCountUI();
        // activate the first dialogue box
        dialogueBox.gameObject.SetActive(true);
        dialogueBox.StartDialogue();
    }

    void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;
            Debug.Log($"Timer：{timer}");
            UpdateTimerUI();

            if (timer <= 0)
            {
                RestartGame(); // reset the game
            }
        }


    }

    public void SimulateShooting()
    {
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

                ResetTimer(); //reset the timer

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

    void SpawnBubble()
    {
        if (!bubbleSpawned)
        {
            StartCoroutine(RespawnBubble());
            bubbleSpawned = true;
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
        bubbleSpawned = false;
    }

    void UpdateKillCountUI()
    {
        killCountText.text = "x" + killCount;
    }

    void UpdateTimerUI()
    {
        timerText.text = timer.ToString("F2");
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

    IEnumerator StartTimer()
    {
        timerRunning = true;
        timer = 3f;
        UpdateTimerUI();
        Debug.Log("Start counting");
        while (timer > 0)
        {
            yield return null; // wait for the next frame
        }
        timerRunning = false;
        Debug.Log("Times up");
        RestartGame();
    }

    void ResetTimer()
    {
        timer = 3f;
        UpdateTimerUI();
        if (!timerRunning)
        {
            StartCoroutine(StartTimer());
        }
    }

    void RestartGame()
    {

        killCount = 0;
        canRespawn = true;
        UpdateKillCountUI();

        dialogueBox.gameObject.SetActive(true);
        dialogueBox.StartDialogue();

        GameObject[] existingBubbles = GameObject.FindGameObjectsWithTag("Bubble");
        foreach (GameObject bubble in existingBubbles)
        {
            Destroy(bubble);
        }

        FindObjectOfType<AimLabManager>().ResetGame();

        StartCoroutine(WaitForDialogueAndSpawnBubble());
    }

    IEnumerator WaitForDialogueAndSpawnBubble()
    {
        yield return new WaitUntil(() => !dialogueBox.gameObject.activeSelf); 
        SpawnBubble();

    }
}