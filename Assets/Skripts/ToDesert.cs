using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToDesert : MonoBehaviour
{
   // SWITCH TO DESERT
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);
    }
}
