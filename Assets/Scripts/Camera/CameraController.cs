using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 500f; // mouse dpi
    public Transform orientation;

    public float maxXRotation = 90f; 
    public float maxYRotation = 90f;
    public float maxZRotation = 90f; 

    private float xRotation;
    private float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //This may useful so you can keep this line, is to keep and lock the mouse in the center of the screen
    }

    void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        // lock the camera rotation
        xRotation = Mathf.Clamp(xRotation, -maxXRotation, maxXRotation);
        yRotation = Mathf.Clamp(yRotation, -maxYRotation, maxYRotation);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}