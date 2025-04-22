using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class ConfigSceneController : MonoBehaviour
{
    public static ConfigSceneController Instance;

    private Vector3 mousePosition;

    [Header("Config")]
    public GameObject bubblePrefab;
    public Transform spawner;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private int volumeIndex; //Only value in 0 to 10 is allowed

    private void Awake()
    {
        Instance = this;
        volumeIndex = PlayerPrefs.GetInt("AudioVolume");

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isBubbleAlive())
        {
            AdjustAudioVolume();
            PlayerPrefs.SetInt("AudioVolume", volumeIndex);
            audioMixer.SetFloat("Master", CalculateAudio_dB());
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
        dB = Mathf.Log10(volumeIndex) * 20;
        return dB;
    }

}
