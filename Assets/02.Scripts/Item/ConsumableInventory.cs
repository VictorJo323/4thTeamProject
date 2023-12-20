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

    public bool HasItem(int itemID)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot != null && slot.item.itemID == itemID && slot.quantity > 0)
            {
                return true; // 아이템이 존재하고 수량이 1개 이상이면 true를 반환
            }
        }
        return false; // 아이템을 찾지 못했으면 false를 반환
    }


    public void RemoveItem(int itemID)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            if (slot != null && slot.item.itemID == itemID)
            {
                slot.quantity--; // 수량 감소
                ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();

                break; // 아이템을 찾고 수량을 감소시켰으므로 루프를 빠져나옵니다.
            }
        }
    }

    public bool UseKey()
    {
        if (HasItem(4)) // 열쇠 아이템의 ID가 4라고 가정
        {
            RemoveItem(4);
            ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();

            return true;
        }
        return false; // 열쇠가 없으면 false 반환
    }

    private int healthPotionID = 1;
    private int healthPotionCount;
    public bool UseHealthPotion()
    {
        // 포션의 수량을 확인하고 사용합니다.
        if (GetPotionCount(healthPotionID) > 0)
        {
            DecreasePotionCount(healthPotionID);
            return true;
        }
        return false;
    }

    private void DecreasePotionCount(int potionID)
    {
        // 포션 수량 감소 로직
        healthPotionCount--;
        ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();
    }

    private int GetPotionCount(int potionID)
    {
        // 포션 수량 반환 로직
        return healthPotionCount;
    }
}
