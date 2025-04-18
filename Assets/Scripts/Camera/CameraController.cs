using UnityEngine;


//THIS SCRIPT IS SUCKS, HELP REWRITE OR REPLACE OTHER SCRIPT
public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 500f; // Mouse's DPI

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //This may useful so you can keep this line, is to keep and lock the mouse in the center of the screen
    }

    void Update()
    {
        // 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}