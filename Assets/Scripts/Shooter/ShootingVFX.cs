using UnityEngine;

public class ShootingVFX : MonoBehaviour
{
    public GameObject gun; 
    public ParticleSystem gunVFX;
    public AudioSource gunfireSound; 
    public DestroyOnClick destroyOnClick; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Play the gunfire sound effect
        if (gunfireSound != null)
        {
            gunfireSound.Play();
        }


        if (gunVFX != null)
        {
            gunVFX.transform.position = gun.transform.position; 
            gunVFX.Play(); 
        }

        // Call the shooting logic from the DestroyOnClick script
        if (destroyOnClick != null)
        {
            destroyOnClick.SimulateShooting(); 
        }
    }
}