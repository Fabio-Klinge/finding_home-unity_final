using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingAlive : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead;

    private void Start()
    {
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true){
            // Set Game Over Code
            //SceneManager.LoadScene(5);
            life = 4;
        }
    }

    public void TakeDamage(int d)
    {
        life -= d;
        Destroy(hearts[life].gameObject);
        if(life < 1)
        {
            dead = true;
        }
    }
}
