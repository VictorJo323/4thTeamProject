using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public ItemSO weaponData;
    public GameObject weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (weaponData.itemType == Type.MeleeWeapon || weaponData.itemType == Type.RangedWeapon))
        {
            WeaponInventory playerWeapon = collision.GetComponent<WeaponInventory>();

            if (playerWeapon != null)
            {
                // 무기 인벤토리에 추가
                Weapon newWeapon = CreateWeaponFromData(weaponData);
                playerWeapon.AddWeapon(newWeapon); // weaponData는 픽업한 무기의 정보

                Destroy(gameObject);
            }
        }
    }

    private Weapon CreateWeaponFromData(ItemSO weaponData)
    {
        // 새 GameObject를 생성합니다.
        GameObject weaponObject = new GameObject(weaponData.itemName);

        // Weapon 컴포넌트를 추가합니다.
        Weapon weaponComponent = weaponObject.AddComponent<Weapon>();

        // ItemSO의 데이터를 사용하여 Weapon 컴포넌트를 초기화합니다.
        weaponComponent.weaponData = weaponData;

        // 생성된 Weapon 객체를 반환합니다.
        return weaponComponent;
    }
}
