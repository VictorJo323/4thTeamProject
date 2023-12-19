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
                // ���� �κ��丮�� �߰�
                Weapon newWeapon = CreateWeaponFromData(weaponData);
                playerWeapon.AddWeapon(newWeapon); // weaponData�� �Ⱦ��� ������ ����

                Destroy(gameObject);
            }
        }
    }

    private Weapon CreateWeaponFromData(ItemSO weaponData)
    {
        // �� GameObject�� �����մϴ�.
        GameObject weaponObject = new GameObject(weaponData.itemName);

        // Weapon ������Ʈ�� �߰��մϴ�.
        Weapon weaponComponent = weaponObject.AddComponent<Weapon>();

        // ItemSO�� �����͸� ����Ͽ� Weapon ������Ʈ�� �ʱ�ȭ�մϴ�.
        weaponComponent.weaponData = weaponData;

        // ������ Weapon ��ü�� ��ȯ�մϴ�.
        return weaponComponent;
    }
}
