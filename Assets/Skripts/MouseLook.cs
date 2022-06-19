using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // To control how fast mouse movements affect camera
    public float mouseSensitivity = 100f;

    // Move player figure along with camera
    public Transform playerBody;
    
    // To save y-coordinates of mouse
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Make cursor invisble and lock at center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get x and y coordinates from mouse location
        // Multiplied by "Time.deltaTime" in order to detach it from framerate switches
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Store rotation of x-axis
        xRotation -= mouseY;
        // Keep xRotation in [-90;90]
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        // Keep track of x-rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}