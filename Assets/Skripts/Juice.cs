using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour
{
    // array of the juice objects
    public GameObject[] juice;
    private int energy;


    private void Start()
    {
        // energy in the beginnging
        energy = 0;
    }


    public void drinkJuice(int d)
    {
        //when called, "old" image deactivated
        juice[energy].gameObject.SetActive(false);

        //new image activated
        energy += d;
        juice[energy].gameObject.SetActive(true);
        
    }
}
