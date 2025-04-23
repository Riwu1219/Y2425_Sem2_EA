using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
public class GoableChangeScence : MonoBehaviour
{
    public bool ThisShooter, ThisKey, ThisPlatformer;
    public DestroyOnClick DestroyOnClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisShooter) 
        {
            if(DestroyOnClick.dialogueBox4.isActiveAndEnabled) 
            {
                StartCoroutine(DelySwitchScreen());
            }
        }
    }

    public void StarScenceEnd() 
    {
        SceneManager.LoadScene(2);
    }

    public void EndScenceStart() 
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator DelySwitchScreen()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(3);
    }
    public void KeyToPlatformer() 
    {
        SceneManager.LoadScene(4);
    }

    public void PlatformerToEnd () 
    {
        SceneManager.LoadScene(5);
    }
}
