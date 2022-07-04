using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScrewInventory screwInventory = other.GetComponent<ScrewInventory>();

        if(screwInventory != null)
        {
            screwInventory.screwCollected();
            gameObject.SetActive(false);
        }
    }
}

