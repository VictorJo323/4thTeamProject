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
            Debug.Log("1���� �߰� " + newWeapon.weaponData.itemName);
        }
        else if(weapons[1] == null)
        {
            weapons[1] = newWeapon;
            Debug.Log("2���� �߰� " + newWeapon.weaponData.itemName);
        }
        else
        {
            DropUnselectedWeapon(weapons[1]);
            Debug.Log("������ ���� " + weapons[1].weaponData.itemName);
            weapons[1] = newWeapon;
            Debug.Log("2���� �߰� " + newWeapon.weaponData.itemName);
        }
    }

    private void DropUnselectedWeapon(Weapon dropWeapon)
    {
        // ����� ������ �������� ã���ϴ�.
        ItemSO itemData = itemDatabase.GetItem(dropWeapon.weaponData.itemName);
        if (itemData != null)
        {
            GameObject weaponPrefab = itemData.prefab;

            // ����� ������ �� �ν��Ͻ��� �����մϴ�.
            GameObject droppedWeaponObject = Instantiate(weaponPrefab, dropPoint.position, Quaternion.identity);

            // �ʿ��� ���, ��ӵ� ���⿡ �߰� ������ �� �� �ֽ��ϴ�.
            // ��: ��ӵ� ������ PickupWeapon ��ũ��Ʈ ���� ��
        }

        // �κ��丮���� ���⸦ �����մϴ�.
        // �� �κ��� �κ��丮 ���� ���� ������Ʈ�� ��Ȱ��ȭ�ϰų� �����ϴ� ���Դϴ�.
        Destroy(dropWeapon.gameObject);
    }
}
