using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openedChest;
    public ItemDatabase itemDatabase; // 무기 아이템 데이터베이스
    public ConsumableInventory consumableInventory; // 플레이어 인벤토리
    public WeaponInventory weaponInventory; // 무기 인벤토리
    public int keyItemID = 4; // 열쇠 아이템의 ID
    public Transform dropPoint;
    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 'Player' 태그를 가진 오브젝트와의 충돌만 처리합니다.
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
            Debug.Log("열쇠가 필요합니다.");
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
