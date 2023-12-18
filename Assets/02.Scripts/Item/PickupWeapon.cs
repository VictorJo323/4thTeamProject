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
        if (collision.CompareTag("Player"))
        {
            WeaponInventory playerWeapon = collision.GetComponent<WeaponInventory>();

            if (playerWeapon != null)
            {
                // ���� �κ��丮�� �߰�
                Weapon newWeapon = CreateWeaponFromData(weaponData);
                playerWeapon.AddWeapon(newWeapon); // weaponData�� �Ⱦ��� ������ ����

                // ������ ��Ȱ��ȭ �Ǵ� ����
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
        // ���⼭�� ���÷� weaponData�� �Ҵ��ϴ� �͸� �����ݴϴ�.
        // ���� ���������� �� ���� �����͸� ������ �� �ֽ��ϴ�.
        weaponComponent.weaponData = weaponData;

        // ������ Weapon ��ü�� ��ȯ�մϴ�.
        return weaponComponent;
    }
}