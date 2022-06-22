using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    // Init character controller for movement
    public CharacterController controller;
    public float movementSpeed = 12f;

    // Default gravity value
    public float gravity = -9.18f;
    // Stores our movement direction  
    Vector3 velocity;



    // Update is called once per frame
    void Update()
    {
        // User presses "d" it will be 1 / "a" -> -1
        float lr = Input.GetAxis("Horizontal");
        // User presses "w" it will be 1 / "s" -> -1
        float updown = Input.GetAxis("Vertical");


        // Direction in comparison to players current position
        Vector3 move = transform.right * lr + transform.forward * updown;
        // Move Character
        // Last term to make it framerate indipendent
        controller.Move(move * movementSpeed * Time.deltaTime);


        // Compute custom gravity
        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        // Apply gravity value
        controller.Move(velocity);
    }
}
