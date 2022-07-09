using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCharBehaviour : MonoBehaviour
{   
    // Save coordinates of main char
    Vector3 mainCoor;

    // Keep track of side char rotation
    public Transform playerBody;

    // To let side char look at main char
    private GameObject mainChar;
    private Vector3 mainCharVec;
    private Quaternion mainCharQuat;

    // Start is called before the first frame update
    void Start()
    {
        mainChar = GameObject.FindGameObjectWithTag("MainChar");
    }

    // Update is called once per frame
    void Update()
    {
        // START POSITION 
        // transform.position = new Vector3(0f, 0f, 0f);

        // Compute point to look at
        mainCharVec = new Vector3(mainChar.transform.position.x, transform.position.y, mainChar.transform.position.z) - transform.position;
        // From it compute Quaternion for rotation
        mainCharQuat = Quaternion.LookRotation(-mainCharVec, Vector3.up);
        // Rotate smoothly and framerate indipendent towards main char
        transform.rotation = Quaternion.Slerp(transform.rotation, mainCharQuat, Time.deltaTime * 2.0f);
    }

    public void VisitMain(string communication)
    {
       // mainChar = GameObject.FindGameObjectWithTag("MainChar")

        // Coordinates of main char as vec3
        mainCoor = GameObject.FindGameObjectWithTag("MainChar").transform.position;

        // Look at main char
        //playerBody.Rotate(mainCoor.x);

        // Don't let side char spawn directly at main char's location
        mainCoor.x = mainCoor.x + 5;



        // Move side char to main char
        transform.position = mainCoor;
    }
}
