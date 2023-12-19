using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class InventorySlot
{
    public ItemSO item;
    public int quantity;

    public InventorySlot(ItemSO newItem, int initQty)
    {
        item = newItem;
        quantity = initQty;
    }
}
public class ConsumableInventory : MonoBehaviour
{
    public InventorySlot[] slots = new InventorySlot[4];

    public void AddConsumable(ItemSO newConsumable)
    {
        if (newConsumable.isStackable)
        {
            int consumableSlot = GetSlot(newConsumable.itemID);
            if(consumableSlot  == -1)
            {
                return;
            }

            if (slots[consumableSlot] == null)
            {
                slots[consumableSlot] = new InventorySlot(newConsumable, 0);
            }
            InventorySlot slot = slots[consumableSlot];
            if (slot.item.itemID == newConsumable.itemID)
            {
                if (slot.quantity < newConsumable.maxQuantity)
                {
                    slot.quantity++;
                }
            }
            else
            {
                //TODO
            }

        }
    }

    private int GetSlot(int itemID)
    {
        switch (itemID)
        {
            case 1:
                return 0;
            case 2:
                return 1;
            case 3:
                return 2;
            case 4:
                return 3;
            default:
                return -1;
        }
    }
}
