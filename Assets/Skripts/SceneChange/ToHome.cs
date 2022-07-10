using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHome : MonoBehaviour
{
   // WHEN COLLIDER IS REACHED, IN TELEPORTER
    public void OnTriggerEnter(Collider other)
    {
        // switch to Home
        SceneManager.LoadScene(1);

        // wait some seconde
        //yield return new WaitForSeconds(5);

        // then switch to the End Scene
        SceneManager.LoadScene(6);
    }



}
