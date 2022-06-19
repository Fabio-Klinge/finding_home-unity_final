using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    // Init character controller for movement
    public CharacterController controller;
    public float movementSpeed = 10f;

    // Default gravity value
    public float gravity = -9.18f;
    // Stores our movement direction  
    Vector3 velocity;

    // Inits to check the sphere of the ground object of the main character
    // Used to check for collision with ground
    public Transform ground;
    // Radius of sphere
    public float groundDist = 0.4f;
    // Controls which layers we want to collide with
    public LayerMask groundMask;
    bool isGrounded;

    // Jumping
    public float jumpValue = 5f;


    // Update is called once per frame
    void Update()
    {
        // Creates Sphere around ground object (from character) and checks wether this sphere
        //  collides with ground
        // Collision: isGrounded = True
        isGrounded = Physics.CheckSphere(ground.position, groundDist, groundMask);
        
        // Collision detected and negative velocity
        if(isGrounded && velocity.y < 0)
        {   
            // Set velocity close to zero to force player to the ground
            velocity.y = -2f;
        }

        // Jump when spacebar is hit and player is on the ground
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Changes y value of character
            // Inspired by physics formula sqrt(height * -2 * gravity)
            velocity.y = Mathf.Sqrt(jumpValue * -2f * gravity);
        }

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




























