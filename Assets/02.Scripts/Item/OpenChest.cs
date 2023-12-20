using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openedChest;
    public ItemDatabase itemDatabase; // ���� ������ �����ͺ��̽�
    public ConsumableInventory consumableInventory; // �÷��̾� �κ��丮
    public WeaponInventory weaponInventory; // ���� �κ��丮
    public int keyItemID = 4; // ���� �������� ID
    public Transform dropPoint;
    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 'Player' �±׸� ���� ������Ʈ���� �浹�� ó���մϴ�.
        if (collision.CompareTag("Player") && !isOpen)
        {
            TryOpenChest();
        }
    }
    public void TryOpenChest()
    {
        if (consumableInventory.UseKey())
        {
            isOpen = true;
            spriteRenderer.sprite = openedChest;
            ItemSO newWeaponData = GetRandomWeaponNotInInventory();
            if (newWeaponData != null)
            {
                DropNewWeapon(newWeaponData);
                Debug.Log("Open and drop new weapon!");
            }
        }
        else
        {
            Debug.Log("���谡 �ʿ��մϴ�.");
        }
    }

    private void DropNewWeapon(ItemSO weaponData)
    {
        GameObject newWeaponObject = Instantiate(weaponData.prefab, dropPoint.position, Quaternion.identity);
    }

    private ItemSO GetRandomWeaponNotInInventory()
    {
        List<ItemSO> availableWeapons = new List<ItemSO>();
        availableWeapons.AddRange(itemDatabase.GetItemsByType(Type.MeleeWeapon));
        availableWeapons.AddRange(itemDatabase.GetItemsByType(Type.RangedWeapon));
        availableWeapons = availableWeapons.FindAll(item => !consumableInventory.HasItem(item.itemID));

        if (availableWeapons.Count > 0)
        {
            int randomIndex = Random.Range(0, availableWeapons.Count);
            return availableWeapons[randomIndex];
        }
        return null;
    }
}
