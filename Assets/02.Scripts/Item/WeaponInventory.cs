using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public Weapon[] weapons = new Weapon[2];
    public ItemDatabase itemDatabase;
    public Transform dropPoint;

    public void AddWeapon(Weapon newWeapon)
    {
        if (weapons[0] == null)
        {
            weapons[0] = newWeapon;
            Debug.Log("1번에 추가 " + newWeapon.weaponData.itemName);
        }
        else if (weapons[1] == null)
        {
            weapons[1] = newWeapon;
            Debug.Log("2번에 추가 " + newWeapon.weaponData.itemName);
        }
        else
        {
            // 먼저 드롭할 아이템의 데이터를 복사하고 드롭 오브젝트를 생성합니다.
            ItemSO dataToDrop = weapons[1].weaponData;
            DropUnselectedWeapon(weapons[1]);
            CreateDroppedWeapon(dataToDrop);
            // 그 후에 인벤토리 슬롯을 새 아이템으로 업데이트합니다.
            Debug.Log("아이템 버림 " + weapons[1].weaponData.itemName);
            weapons[1] = newWeapon;
            Debug.Log("2번에 추가 " + newWeapon.weaponData.itemName);
        }

        if (ShowWeaponInventory.Instance != null)
        {
            ShowWeaponInventory.Instance.UpdateInventoryImage();
        }
    }

    private void CreateDroppedWeapon(ItemSO dataToDrop)
    {
        // 드롭할 무기의 프리팹을 찾습니다.
        GameObject weaponPrefab = dataToDrop.prefab; 

        // 드롭할 무기의 새 인스턴스를 생성합니다.
        GameObject droppedWeaponObject = Instantiate(weaponPrefab, dropPoint.position, Quaternion.identity);

        // 드롭된 아이템에 대한 PickupWeapon 컴포넌트를 설정합니다.
        PickupWeapon pickupComponent = droppedWeaponObject.GetComponent<PickupWeapon>();
        if (pickupComponent != null)
        {
            pickupComponent.weaponData = dataToDrop; 
        }
    }

    private void DropUnselectedWeapon(Weapon dropWeapon)
    {
        // 인벤토리에서 무기를 제거합니다.
        Destroy(dropWeapon.gameObject);
    }

    private void Start()
    {
        ShowWeaponInventory.Instance.UpdateInventoryImage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Weapon temp = weapons[0];
            weapons[0] = weapons[1];
            weapons[1] = temp;
            Debug.Log("1슬롯: " + weapons[0].name + "  2슬롯: " + weapons[1].name);
            ShowWeaponInventory.Instance.UpdateInventoryImage();

        }
    }
}
