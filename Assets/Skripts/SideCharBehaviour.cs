using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Texts
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;
    public GameObject sixth;

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

    // Plays at first move of player
    public void Opening(string communication)
    {
        VisitMain("communication");

        first.SetActive(true);
        Invoke("DeleteFirst", 4.0f);

    }
  
    public void TalkAboutMeggaJump(string communication)
    {
        Debug.Log("huhu");
        VisitMain("communication");

        fifth.SetActive(true);
        Invoke("Deletefifth", 4.0f);
    }



  

    // Functions to toggle text and open new one
    public void DeleteFirst()
    {
        first.SetActive(false);
        second.SetActive(true);
        Invoke("DeleteSecond", 4.0f);

    }

    public void DeleteSecond()
    {
        second.SetActive(false);
        third.SetActive(true);
        Invoke("DeleteThird", 5.0f);
    }

    public void DeleteThird()
    {
        third.SetActive(false);
        fourth.SetActive(true);
        Invoke("DeleteFourth", 3.0f);
    }

    public void DeleteFourth()
    {
        fourth.SetActive(false);
        //1 = home
        //2 = startscreen
        //3 = Game Over
        //4 = desert
        //5 = miniworld
        SceneManager.LoadScene(4);
    }

    public void Deletefifth()
    {
        fifth.SetActive(false);
        sixth.SetActive(true);
        Invoke("Deletesixth", 5.0f);
    }

    public void Deletesixth()
    {
        sixth.SetActive(false);
    }
}



