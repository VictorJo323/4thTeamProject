using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupConsumable : MonoBehaviour
{
    public ItemSO consumableData;
    public GameObject consumablePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ConsumableInventory playerConsumable = collision.GetComponent<ConsumableInventory>();

            if (playerConsumable != null)
            {
                // 소모품 인벤토리에 추가
                playerConsumable.AddConsumable(consumableData);
                ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();
                Destroy(gameObject);
            }
        }
    }
}
