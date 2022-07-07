using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCharBehaviour : MonoBehaviour
{
    Vector3 mainCoor;
    // Start is called before the first frame update
    void Start()
    {
        VisitMain("bitchass");
    }

    // Update is called once per frame
    void Update()
    {
        // START POSITION 
        transform.position = new Vector3(0f, 0f, 0f);
    }

    public void VisitMain(string test)
    {
        Debug.Log("VisitMain is accessed" + test);

        // Coordinates of main char as vec3
        mainCoor = GameObject.FindGameObjectWithTag("MainChar").transform.position;

        // Move side char to main char
        transform.position = transform.position + mainCoor;
    }
}
