using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemDatabase itemDatabase; // ItemDatabase에 대한 참조
    public float dropChance = 1f; // 드랍 확률

    public void DropItem()
    {
        Debug.Log("DropItem called"); // 메서드 호출 확인

        if (Random.value <= dropChance)
        {
            List<ItemSO> consumableItems = itemDatabase.GetItemsByType(Type.Consumable);
            Debug.Log("Found " + consumableItems.Count + " consumable items"); // 아이템 리스트 크기 확인

            if (consumableItems.Count > 0)
            {
                int randomIndex = Random.Range(0, consumableItems.Count);
                ItemSO itemToDrop = consumableItems[randomIndex];
                Debug.Log("Dropping item: " + itemToDrop.itemName); // 아이템 생성 로그

                Instantiate(itemToDrop.prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
