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
        if(weapons[0] == null)
        {
            weapons[0] = newWeapon;
            Debug.Log("1번에 추가 " + newWeapon.weaponData.itemName);
        }
        else if(weapons[1] == null)
        {
            weapons[1] = newWeapon;
            Debug.Log("2번에 추가 " + newWeapon.weaponData.itemName);
        }
        else
        {
            DropUnselectedWeapon(weapons[1]);
            Debug.Log("아이템 버림 " + weapons[1].weaponData.itemName);
            weapons[1] = newWeapon;
            Debug.Log("2번에 추가 " + newWeapon.weaponData.itemName);
        }
    }

    private void DropUnselectedWeapon(Weapon dropWeapon)
    {
        // 드롭할 무기의 프리팹을 찾습니다.
        ItemSO itemData = itemDatabase.GetItem(dropWeapon.weaponData.itemName);
        if (itemData != null)
        {
            GameObject weaponPrefab = itemData.prefab;

            // 드롭할 무기의 새 인스턴스를 생성합니다.
            GameObject droppedWeaponObject = Instantiate(weaponPrefab, dropPoint.position, Quaternion.identity);

            // 필요한 경우, 드롭된 무기에 추가 설정을 할 수 있습니다.
            // 예: 드롭된 무기의 PickupWeapon 스크립트 설정 등
        }

        // 인벤토리에서 무기를 제거합니다.
        // 이 부분은 인벤토리 내의 무기 오브젝트를 비활성화하거나 제거하는 것입니다.
        Destroy(dropWeapon.gameObject);
    }
}
