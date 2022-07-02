using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mini_World : MonoBehaviour
{
     // SWITCH TO MINI WORLD
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
