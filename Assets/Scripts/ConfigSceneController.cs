using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class ConfigSceneController : MonoBehaviour
{
    public static ConfigSceneController Instance;

    private Vector3 mousePosition;

    [Header("Component")]
    public GameObject bubblePrefab;
    public Transform spawner;

    [Header("GetUI")]
    public TextMeshProUGUI volumeIndexText;
    public Animator volumeIndexAnimator;
    public Dialogue dialogue;
    public GameObject LoadinMenu;

    [Header("Status")]
    public bool canAdjust = false;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private int volumeIndex; //Only value in 0 to 10 is allowed

    [Header("MouseHold tracking")]
    private bool isHolding = false;
    private float holdDuration = 3f;

    private void Awake()
    {
        Instance = this;
        volumeIndex = PlayerPrefs.GetInt("AudioVolume");
        volumeIndexText.text = "" + volumeIndex;
    }

    private void Start()
    {
        dialogue.StartFirstDialogue();
    }

    private void Update()
    {
        //check if dialog end function
        if (dialogue.triggerEvent)
        {
            Debug.Log("Goup");
            LoadinMenu.GetComponent<Animator>().Play("GoUp_anim");
            canAdjust = true;
        }

        if (Input.GetMouseButtonDown(0) && !isBubbleAlive() && canAdjust)
        {
            CheckMouseHold();
            AdjustAudioVolume();
            PlayerPrefs.SetInt("AudioVolume", volumeIndex);
            volumeIndexAnimator.Play("VolumeText_Fade_anim");
            audioMixer.SetFloat("Master", CalculateAudio_dB());
            volumeIndexText.text = "" + volumeIndex;
        }

    }

    private void AdjustAudioVolume()
    {
        switch (GetMouseOnViewportSide(GetMouseViewportLocation()))
        {
            //If 0, null | If 1, Left | If 2, Right
            case 0:
                Debug.Log("Get:0 ,TestAudioVolume");
                Debug.Log("MousePosition" + mousePosition);
                Instantiate(bubblePrefab, spawner).GetComponent<bubbleMovement>().disableControl = true;
                break;

            case 1:
                Instantiate(bubblePrefab, spawner).GetComponent<bubbleMovement>().disableControl = true;
                volumeIndex--;
                break;

            case 2:
                Instantiate(bubblePrefab, spawner).GetComponent<bubbleMovement>().disableControl = true;
                volumeIndex++;
                break;
        }

    }

    private int GetMouseOnViewportSide(float value)
    {
        //If leftside :0 false
        if (mousePosition.x > 0 && mousePosition.x < 0.33)
        {
            return 1;
        }

        //If rightside :1 true
        if (mousePosition.x > 0.66 && mousePosition.x <= 1)
        {
            return 2;
        }

        return 0;
    }

    private float GetMouseViewportLocation()
    {
        mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        return (mousePosition.x);
    }

    private bool isBubbleAlive()
    {
        return GameObject.FindGameObjectWithTag("Bubble");
    }

    private float CalculateAudio_dB()
    {
        //Confirm
        volumeIndex = Mathf.Clamp(volumeIndex, 0, 10);
        float dB = volumeIndex / 10f;
        Debug.Log(dB);
        dB = Mathf.Log10(dB) * 20;
        return dB;
    }

    private void CheckMouseHold()
    {
        if (Input.GetMouseButton(0)) // 0 is the left mouse button
        {
            if (!isHolding)
            {
                StartCoroutine(HoldMouse());
            }
        }
        else
        {
            isHolding = false;
        }
    }

    private IEnumerator HoldMouse()
    {
        isHolding = true;
        float timer = 0f;

        while (timer < holdDuration)
        {
            timer += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Trigger the desired action after holding for 3 seconds
        SwitchScene();
    }

    private void SwitchScene()
    {
        Debug.Log("Mouse held for 3 seconds!");
        SceneManager.LoadScene(1);
    }
}
