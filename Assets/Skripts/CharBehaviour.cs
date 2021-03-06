using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBehaviour : MonoBehaviour
{

    // Side char script
    SideCharBehaviour sideChar;
    
    // Init character controller for movement
    public CharacterController controller;

    // Chracter speed
    [SerializeField]
    private float movementSpeed = 12f;

    // Default gravity value
    [SerializeField]
    private float gravity = -18;
    // Stores our movement direction  
    Vector3 velocity;

    // Chracter on Ground
    public bool isGrounded;

    // Jumping
    [SerializeField]
    private float jumpValue = 20f;
    private float yspeed; 

    // lives Manager
    public BeingAlive beingAlive;

    // To switch between cursor lock states
    private bool cursor_lock = true;

    // Display opening only once
    private bool once = true;


    void Start()
    {
        // Program starts
        Debug.Log("I am starting");

        // START POSITION 
        //transform.position = new Vector3(0f, 0f, 0f);

        // Import other script
        sideChar = GameObject.FindGameObjectWithTag("SideChar").GetComponent<SideCharBehaviour>();



    }


    // Update is called once per frame
    void Update()
    {

        // Leads to faster updates of the controller.isGrounded flag
        if (controller.isGrounded)
        {
            isGrounded = true;
        }

        // NEW WAY TO CAP VELOCITY
        // Collision detected and negative velocity on y axis
        if (isGrounded && velocity.y < 0)
        {
            // Resets velocity
            // Small negative velocity to push player to the ground
            velocity.y = -2f;
        }


        // User presses "d" it will be 1 / "a" -> -1
        float lr = Input.GetAxis("Horizontal");
        // User presses "w" it will be 1 / "s" -> -1
        float updown = Input.GetAxis("Vertical");

        // Direction in comparison to players current position/direction
        Vector3 move = transform.right * lr + transform.forward * updown;
        // Move Character
        // Last term to make movement framerate indipendent
        controller.Move(move * movementSpeed * Time.deltaTime);

        // Jump when spacebar is hit and player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("why no jump then");
            // Changes y movement direction of character
            // Inspired by physics formula sqrt(height * -2 * gravity)
            //velocity.y = Mathf.Sqrt(jumpValue * 2f * gravity);
            velocity.y += jumpValue;
        }

        // Megga Jump
        if (Input.GetKeyDown(KeyCode.J) && isGrounded)
        {
            Debug.Log("why no jump then");
            // Changes y movement direction of character
            velocity.y += jumpValue + 50;
        }

        // Compute custom gravity
        velocity.y += gravity * Time.deltaTime;
        // Apply gravity value
        controller.Move(velocity * Time.deltaTime);


        // Interact with side char
        if (Input.GetKeyDown(KeyCode.H))
        {
            sideChar.VisitMain("communication");
        }

        // Interact with side char
        if (Input.GetKeyDown(KeyCode.O))
        {
            sideChar.Opening("communication");
        }

        // Interact with side char
        if (Input.GetKeyDown(KeyCode.P))
        {
            sideChar.TalkAboutMeggaJump("communication");
        }


        // Test side char
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (cursor_lock)
            {

                // Make cursor invisible and lock at center of screen
                Cursor.lockState = CursorLockMode.Confined;
                cursor_lock = false;
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursor_lock = true;
            }
        }

        // Reset Groundcheck
        isGrounded = false;

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
            transform.position = new Vector3(1592.54f, 101.2f, 509.9f);
            // Lose 1 life 
            beingAlive.TakeDamage(1);
        }
    }
}




























