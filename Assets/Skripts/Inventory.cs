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
        // List to store items
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


    public void Tester()
    {
        Debug.Log("am being called");
    }

    public void UseItem(int i)
    {
        Debug.Log("am being called");

        // Check whether there is an item in slot
        if (i < items.Count)
        {
            // For all different Items
            switch (items[i].name)
            {
                case "Screw":
                    {
                        // Using item
                        usingItem.SetActive(true);
                        // Function call to delete text
                        Invoke("ItemDone", 1);
                        // Delete item from inventory
                        items.RemoveAt(i);
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
        for (int i = 0; i < inventory.Length; i++)
        {
            // Check whether there is an item in slot
            if (i < items.Count)
            {
                // Match different Items
                switch (items[i].name)
                {
                    case "Screw":
                        {
                            // Choose right graphic even for multiple items
                            inventory[i].sprite = Itemgraphic;
                            // Make graphic visual
                            col.a = 1;
                            // Set color of inventory
                            inventory[i].color = col;
                            break;

                        }
                }
            }
            // No item
            else
            {
                // No graphic
                inventory[i].sprite = null;
                // Invisible
                col.a = 0;
                // Set color of inventory
                inventory[i].color = col;
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Tagged object near player
        if (collision.tag == "Screw")
        {
            // Inventory is full
            if (items.Count >= limit)
            {   
                // Display text
                fullInv.SetActive(true);
                Invoke("RidText", 1);

            }

            // Inventory has space left
            else
            {
                AddItem(collision.gameObject);
            }
        }

    }


    // Toggle text for full inventory
    void RidText()
    {
        fullInv.SetActive(false);
    }

    // Toggle text for a used up item
    void ItemDone()
    {
        usingItem.SetActive(false);
    }
}