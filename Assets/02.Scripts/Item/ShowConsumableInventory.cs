using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowConsumableInventory : MonoBehaviour
{
    public ConsumableInventory consumableInventory;
    public Image consumableSlot1;
    public Image consumableSlot2;
    public Image consumableSlot3;
    public Image consumableSlot4;

    public TextMeshProUGUI quantityCounter1;
    public TextMeshProUGUI quantityCounter2;
    public TextMeshProUGUI quantityCounter3;
    public TextMeshProUGUI quantityCounter4;

    public static ShowConsumableInventory Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void UpdateConsumableInventoryUI()
    {
        UpdateSlot(consumableSlot1, quantityCounter1, consumableInventory.slots[0]);
        UpdateSlot(consumableSlot2, quantityCounter2, consumableInventory.slots[1]);
        UpdateSlot(consumableSlot3, quantityCounter3, consumableInventory.slots[2]);
        UpdateSlot(consumableSlot4, quantityCounter4, consumableInventory.slots[3]);
    }

    private void UpdateSlot(Image consumableSlot, TextMeshProUGUI quantityCounter, InventorySlot inventorySlot)
    {
        if (inventorySlot != null)
        {
            consumableSlot.sprite = inventorySlot.item.icon;
            consumableSlot.enabled = true;

            if (inventorySlot.quantity > 0)
            {
                consumableSlot.color = Color.white;
                quantityCounter.text = inventorySlot.quantity.ToString();
                quantityCounter.enabled = true;
            }
            else
            {
                consumableSlot.color = Color.grey;
                quantityCounter.text = "0";
                quantityCounter.enabled = true;
            }
        }
        else
        {
            consumableSlot.enabled = false;
            quantityCounter.enabled = false;
        }
    }
}