using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniWorld : MonoBehaviour
{
     // SWITCH TO MINI WORLD
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MiniWorld"))
        {
            SceneManager.LoadScene(5);
        }    
    }
}

