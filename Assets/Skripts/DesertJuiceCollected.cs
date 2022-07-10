using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertJuiceCollected : MonoBehaviour
{
    // Desert juice objects
    public GameObject juice1;
    public GameObject juice2;
    public GameObject juice3;
    public GameObject juice4;
    public GameObject juice5;

    // Side char script
    SideCharBehaviour sideChar;



    // Start is called before the first frame update
    void Start()
    {
        // Import other script
        sideChar = GameObject.FindGameObjectWithTag("SideChar").GetComponent<SideCharBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(juice1.active & juice2.active & juice3.active & juice4.active & juice5.active))
        {
            // Go back to start world
            SceneManager.LoadScene(0);

            // Call sideChar
            //sideChar.TalkAboutMeggaJump("communication");
        }
    }
}
