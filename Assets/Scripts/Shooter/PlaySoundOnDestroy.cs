using UnityEngine;

public class PlaySoundOnDestroy : MonoBehaviour
{
    public AudioSource deadSound; 

    public void PlayDeadSound()
    {
        if (deadSound != null)
        {
            deadSound.Play();
        }
    }
}