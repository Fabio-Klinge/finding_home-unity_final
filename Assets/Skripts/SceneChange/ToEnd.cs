using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToEnd : MonoBehaviour
{
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(10);

        // then switch to the End Scene
        SceneManager.LoadScene(6);
    }


    //or when  entered the door of the house
    public void OnTriggerEnter(Collider other)
    {
        // switch to End
        SceneManager.LoadScene(6);
    }
}
