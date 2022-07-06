using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    
    
    // Init character controller for movement
    public CharacterController controller;
    public float movementSpeed = 12f;

    // Default gravity value
    private float gravity = -9.18f;
    // Stores our movement direction  
    Vector3 velocity;

    // Inits to check the sphere of the ground object of the main character
    // Center of the sphere
    public Transform ground;
    // Radius of sphere
    public float groundDist = 0.4f;
    // Controls which layers we want to collide with
    public LayerMask groundMask;
    public bool isGrounded;

    // Jumping
    public float jumpValue = 100f;
    
    //UI_Manager for lifes
    //[SerializeField]
    //private Ui_Manager uiManager :;

    // lives Manager
    private BeingAlive beingAlive;


    void Start()
    {
        // START POSITION 
        transform.position = new Vector3(0f, 0f, 0f);

    }


    // Update is called once per frame
    void Update()
    {
        // Creates Sphere around ground object (from character) and checks wether this sphere
        //  collides with ground
        // Collision: isGrounded = True
        isGrounded = Physics.CheckSphere(ground.position, groundDist, groundMask);

        // Collision detected and negative velocity on y axis
      //  if (isGrounded && velocity.y < 0)
        //{
            // Small negative velocity to push player to the ground
         //   velocity.y = -2f;
        //}

        // User presses "d" it will be 1 / "a" -> -1
        float lr = Input.GetAxis("Horizontal");
        // User presses "w" it will be 1 / "s" -> -1
        float updown = Input.GetAxis("Vertical");

        // Direction in comparison to players current position
        Vector3 move = transform.right * lr + transform.forward * updown;
        // Move Character
        // Last term to make it framerate indipendent
        controller.Move(move * movementSpeed * Time.deltaTime);

        // Jump when spacebar is hit and player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Changes y movement direction of character
            // Inspired by physics formula sqrt(height * -2 * gravity)
            //velocity.y = Mathf.Sqrt(jumpValue * -2f * gravity);
            velocity.y += jumpValue;
        }

        // Compute custom gravity
        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        // Apply gravity value
        controller.Move(velocity);

        Border();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "youshallnotpass")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }

    // transfrom to position on platfrom when left platfrom 
    // takeDamage to lose a life
    void Border()
    {
        // CHANGE If statement for falling down (side / fallschaden
        if(transform.position.y < -10)
        {   
            // Reset position SET TO START POINT
            transform.position = new Vector3(0f, 2f, 0f);
            // Lose 1 life 
            beingAlive.TakeDamage(1);
        }
    }
}




























