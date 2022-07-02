using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertJuice : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite[] juice;

    // Load all sprites and set first, empty juice
    void Start()
    {
      rend GetComponent<SpriteRenderer>();
      juice[0] = Ressources.Load<Sprite>();
      juice[1] = Ressources.Load<Sprite>();
      juice[2] = Ressources.Load<Sprite>();
      juice[3] = Ressources.Load<Sprite>();
      rend.sprite = juice1;
    }

    // Update is called once per frame
    void Update()
    {
        // if juice collectet
        if()
        {
            rend.sprite = juice[juicecollected];
        }
        
    }
}
