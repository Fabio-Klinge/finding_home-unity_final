using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrewInventory : MonoBehaviour
{
    public int numberScrew {get; private set; }

    public UnityEvent<ScrewInventory> Collected;

    public void screwCollected()
    {
        numberScrew++;
        Collected.Invoke(this);
    }
}
