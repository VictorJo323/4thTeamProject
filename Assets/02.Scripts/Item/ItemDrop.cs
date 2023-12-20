using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemDatabase itemDatabase; // ItemDatabase�� ���� ����
    public float dropChance = 1f; // ��� Ȯ��

    public void DropItem()
    {
        Debug.Log("DropItem called"); // �޼��� ȣ�� Ȯ��

        if (Random.value <= dropChance)
        {
            List<ItemSO> consumableItems = itemDatabase.GetItemsByType(Type.Consumable);
            Debug.Log("Found " + consumableItems.Count + " consumable items"); // ������ ����Ʈ ũ�� Ȯ��

            if (consumableItems.Count > 0)
            {
                int randomIndex = Random.Range(0, consumableItems.Count);
                ItemSO itemToDrop = consumableItems[randomIndex];
                Debug.Log("Dropping item: " + itemToDrop.itemName); // ������ ���� �α�

                Instantiate(itemToDrop.prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
