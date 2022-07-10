using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeingAlive : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead;

    private void Start()
    {
        life = 3;
    }

    // Update is called once per frame   WARUM LIFE=4?
    void Update()
    {
        if(dead == true){
            // Set Game Over Code
            SceneManager.LoadScene(3);
            //life = 4;
        }
    }

    public void TakeDamage(int d)
    {
        life -= d;
        Debug.Log("You lost a life");
        Debug.Log("Actual life: "+ life);

        Destroy(hearts[life].gameObject);
        if(life < 1)
        {
            dead = true;
        }
    }
}
