using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Texts
    public GameObject fullInv;
    public GameObject usingItem;
    // Needs to be an array to have different items
    public Sprite Itemgraphic;
    // For buttons on inventory
    public Image[] inventory;

    private List<GameObject> items;
    private Color col;
    private int limit;




    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();

        // To manipulate aplha channel of graphics -> make them disappear 
        col = Color.white;
        limit = 5;

        // Deactivate texts
        fullInv.SetActive(false);
        usingItem.SetActive(false);

        //
        Display();




    }

    void AddItem(GameObject item)
    {
        items.Add(item);
        item.SetActive(false);
        Display();
    }

    public void UseItem (int i)
    {
        // Check whether there is an item in slot
        if(i < items.Count)
        {
            // For all different Items
            switch(items[i.name])
            {
                case "Screw"
                    {
                        // Using item
                        usingItem.SetActive("true");
                        // Function call to delete text
                        Envoke("ItemDone", 1);
                        // Delete item from inventory
                        items.RemoveAt[i];
                        Display();
                        break;

                    }
            }
        }
    }

    void Display()
    {
        // Loop over all items
        // Check for our item (i < items.Count)
        for(int i = 0; i < inventory.Length; i++)
        {
            // Check whether there is an item in slot
            if (i < items.Count)
            {
                // For all different Items
                switch (items[i.name])
                {
                    case "Screw"
                        {
                            break;

                        }
                }
            }
        }
    }
}
