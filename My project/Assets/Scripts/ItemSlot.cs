using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System;
//using UnityEngine.UIElements;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{


    // -----item data--------//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField]
    private int maxNumberOfItems;

    //------item slot--------//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    //------item description slot-----//
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemseleted;

    //reference
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //check to if slot is full
        if (isFull)
            return quantity;

        //update NAME
        this.itemName = itemName;


        //update IMAGE
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;


        //update DESCRIPTION
        this.itemDescription = itemDescription;

        //update QUANTITY
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;

            //return the LEFTOVERS
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //update QUANTITY TEXT
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {

        //to use item, click again the item that was selected
        if (thisItemseleted)
        {
            bool usable = inventoryManager.UseItem(itemName);
            inventoryManager.UseItem(itemName);
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
                EmptySlot();
        }

        else
        {
            //referencing
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemseleted = true;
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = itemDescription;
            ItemDescriptionImage.sprite = itemSprite;
            if (ItemDescriptionImage.sprite == null)
                ItemDescriptionImage.sprite = emptySprite;
        }
    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        ItemDescriptionImage.sprite = emptySprite;
        /*
        quantity = 0;
        itemName = string.Empty;
        itemDescription = string.Empty;
        itemSprite = emptySprite;
        isFull = false;

        // Reset UI components
        quantityText.text = string.Empty;
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        // Reset description details
        ItemDescriptionNameText.text = string.Empty;
        ItemDescriptionText.text = string.Empty;
        ItemDescriptionImage.sprite = emptySprite;

        // Deselect slot
        selectedShader.SetActive(false);
        thisItemseleted = false;
        */
    }

    public void OnRightClick()
    {


    }
} 