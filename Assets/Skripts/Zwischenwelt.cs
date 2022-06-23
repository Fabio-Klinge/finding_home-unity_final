using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zwischenwelt : MonoBehaviour
{
     // SWITCH TO ZWISCHENWELT
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
