using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UserConfiguration : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        LoadMusicVolume();
        
    }

    public void LoadMusicVolume()
    {
        float volume = PlayerPrefs.GetInt("AudioVolume") / 10f;
        Debug.Log(PlayerPrefs.GetInt("AudioVolume"));
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
}
