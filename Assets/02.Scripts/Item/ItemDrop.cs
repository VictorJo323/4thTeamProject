using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemDatabase itemDatabase; // ItemDatabase�� ���� ����
    public float dropChance = 0.1f; // ��� Ȯ��

    public void DropItem()
    {
        if (Random.value <= dropChance)
        {
            List<ItemSO> consumableItems = itemDatabase.GetItemsByType(Type.Consumable);
            if (consumableItems.Count > 0)
            {
                int randomIndex = Random.Range(0, consumableItems.Count);
                ItemSO itemToDrop = consumableItems[randomIndex];
                Instantiate(itemToDrop.prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
