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
    private void Awake()
    {
        ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();

    }
    public InventorySlot[] slots = new InventorySlot[4];

    public bool AddConsumable(ItemSO newConsumable)
    {
        if (newConsumable.isStackable)
        {
            int consumableSlot = GetSlot(newConsumable.itemID);
            if(consumableSlot  == -1)
            {
                return false ;
            }

            if (slots[consumableSlot] == null)
            {
                slots[consumableSlot] = new InventorySlot(newConsumable, 1);
                return true;
            }
            else
            { 
                InventorySlot slot = slots[consumableSlot];
                if (slot.item.itemID == newConsumable.itemID)
                {
                    if (slot.quantity < newConsumable.maxQuantity)
                    {
                        slot.quantity++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        else
        { 
            return false;
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

    public bool HasItem(int itemID)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot != null && slot.item.itemID == itemID && slot.quantity > 0)
            {
                return true; // �������� �����ϰ� ������ 1�� �̻��̸� true�� ��ȯ
            }
        }
        return false; // �������� ã�� �������� false�� ��ȯ
    }


    public void RemoveItem(int itemID)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            if (slot != null && slot.item.itemID == itemID)
            {
                slot.quantity--; // ���� ����
                ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();

                break; // �������� ã�� ������ ���ҽ������Ƿ� ������ �������ɴϴ�.
            }
        }
    }

    public bool UseKey()
    {
        if (HasItem(4)) // ���� �������� ID�� 4��� ����
        {
            RemoveItem(4);
            ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();

            return true;
        }
        return false; // ���谡 ������ false ��ȯ
    }



    private int healthPotionID = 1;
    private int healthPotionCount;
    public bool UseHealthPotion()
    {
        int slotIndex = GetSlot(healthPotionID);
        if (slotIndex != -1 && slots[slotIndex] != null && slots[slotIndex].quantity > 0)
        {
            slots[slotIndex].quantity--;
            ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();
            return true;
        }
        return false;
    }
}
