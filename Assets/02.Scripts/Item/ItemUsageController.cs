using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsageController : MonoBehaviour
{
    public ConsumableInventory consumableInventory;
    public CharacterStatsHandler characterStats;
    public HealthSystem healthSystem;

    private Dictionary<int, float> lastUseTimes = new Dictionary<int, float>();
    private Dictionary<int, float> itemCooldowns = new Dictionary<int, float>()
    {
        { 1, 10.0f },
        { 2, 10.0f }
    };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(1); // 1번 아이템 사용
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(2); // 2번 아이템 사용
        }
    }

    private void UseItem(int itemID)
    {
        if (!CanUseItem(itemID))
            return;

        InventorySlot slot = consumableInventory.slots[itemID - 1];
        if (slot != null && slot.quantity > 0)
        {
            ApplyItemEffect(slot.item);
            slot.quantity--;
            lastUseTimes[itemID] = Time.time;
            ShowConsumableInventory.Instance?.UpdateConsumableInventoryUI();
        }
    }

    private bool CanUseItem(int itemID)
    {
        if (!lastUseTimes.ContainsKey(itemID))
            lastUseTimes[itemID] = 0;

        return Time.time >= lastUseTimes[itemID] + itemCooldowns[itemID];
    }

    private void ApplyItemEffect(ItemSO item)
    {
        switch (item.itemID)
        {
            case 1:
                healthSystem.ChangeHealth(20); // 20 체력 회복
                break;
            // 다른 아이템 효과에 대한 처리...
            case 2:
                break;
        }
    }
}
