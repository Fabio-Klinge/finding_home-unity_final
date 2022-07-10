using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(4);
    }
    
}
