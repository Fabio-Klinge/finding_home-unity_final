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


    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // Decreased as long as camera shakes
    [SerializeField]
    private float shakeTime = 0f;
    private float decreaseFactor = 1.0f;

    // How much the camera shakes
    [SerializeField]
    private float shakeStrength = 20f;
    
    // Save position of camera
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        // Make cursor invisble and lock at center of screen
        Cursor.lockState = CursorLockMode.Locked;

        // Position of camera
        pos = camTransform.localPosition;
        // Start shaking camera
        shakeTime = 4;

    }

    // Update is called once per frame
    void Update()
    {
        // Cam shaking for start of the game
        if (shakeTime > 0)
        {
            // Shaking effect by adding random values to cam position
            camTransform.localPosition = pos + Random.insideUnitSphere * shakeStrength;
            // Decrease in order to stop shaking
            shakeTime -= Time.deltaTime * decreaseFactor;
        }

        else
        {
            shakeTime = 0f;
            // Reset to orginal position
            camTransform.localPosition = pos;
        }


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
        // Vector to rotate the player by
        playerBody.Rotate(Vector3.up * mouseX);
    }
}