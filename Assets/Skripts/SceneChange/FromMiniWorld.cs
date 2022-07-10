using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromMiniWorld : MonoBehaviour
{
     // SWITCH TO MINI WORLD
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Screw"))
        {
            SceneManager.LoadScene(0);
        }    
    }
}
