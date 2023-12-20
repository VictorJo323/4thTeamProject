using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Item/ItemDatabase", order = 0)]
public class ItemDatabase : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();

    public ItemSO GetItem(string itemName)
    {
        foreach (ItemSO item in items)
        {
            if (item.itemName == itemName)
            {
                return item;
            }
        }
        return null;
    }

    public List<ItemSO> GetItemsByType(Type itemType)
    {
        List<ItemSO> filteredItems = new List<ItemSO>();
        foreach (ItemSO item in items)
        {
            if (item.itemType == itemType)
            {
                filteredItems.Add(item);
            }
        }
        return filteredItems;
    }
}
