using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;

    //reference
    public Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // If playerHealth is not assigned in the Inspector, find it programmatically
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
            if (playerHealth == null)
            {
                Debug.LogError("Health component reference is missing or not attached to the Player GameObject.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("Inventory") && menuActivated)
            {
                Time.timeScale = 1;
                InventoryMenu.SetActive(false);
                menuActivated = false;
            }
            else if (Input.GetButtonDown("Inventory") && !menuActivated)
            {
                Time.timeScale = 0;
                InventoryMenu.SetActive(true);
                menuActivated = true;
            }
        }
    }


    /*
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                if (leftOverItems > 0)
                
                leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                return leftOverItems;
                
            }
            

        }


        return quantity;
    }*/


    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem(playerHealth);
                if (usable)
                {
                    return true;
                }
            }

        }
        return false;
    }
    /*   public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
       {
           for (int i = 0; i < itemSlot.Length; i++)
           {
               // Check if the slot is either empty or matches the item
               if (!itemSlot[i].isFull && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0))
               {
                   // Try to add the item to the slot
                   int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                   // If there are leftovers, attempt to find another slot for them
                   if (leftOverItems > 0)
                   {
                       // Search for another slot without calling recursively on itself
                       for (int j = i + 1; j < itemSlot.Length; j++)
                       {
                           if (!itemSlot[j].isFull && (itemSlot[j].itemName == itemName || itemSlot[j].quantity == 0))
                           {
                               leftOverItems = itemSlot[j].AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                               if (leftOverItems <= 0)
                               {
                                   return 0; // Stop once all items are placed
                               }
                           }
                       }
                   }
                   return leftOverItems; // Return if all items cannot be placed
               }
           }

           // Return the original quantity if no slot was found
           return quantity;
       }
    */
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            // Check if the slot is either empty or matches the item
            if (!itemSlot[i].isFull && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0))
            {
                // Only allow adding if quantity > 0
                if (quantity > 0)
                {
                    int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                    if (leftOverItems > 0)
                    {
                        for (int j = i + 1; j < itemSlot.Length; j++)
                        {
                            if (!itemSlot[j].isFull && (itemSlot[j].itemName == itemName || itemSlot[j].quantity == 0))
                            {
                                leftOverItems = itemSlot[j].AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                                if (leftOverItems <= 0)
                                {
                                    return 0; // Stop once all items are placed
                                }
                            }
                        }
                    }
                    return leftOverItems;
                }
            }
        }

        return quantity; // No slot found
    }


    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemseleted = false;
        }
    }

}