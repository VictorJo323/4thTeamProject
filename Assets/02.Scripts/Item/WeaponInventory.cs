using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public event Action<ItemSO> OnWeaponChanged;

    public Weapon[] weapons = new Weapon[2];
    public ItemDatabase itemDatabase;
    public Transform dropPoint;

    public void AddWeapon(Weapon newWeapon)
    {
        if (weapons[0] == null)
        {
            weapons[0] = newWeapon;
            Debug.Log("1���� �߰� " + newWeapon.weaponData.itemName);

        }
        else if (weapons[1] == null)
        {
            weapons[1] = newWeapon;
            Debug.Log("2���� �߰� " + newWeapon.weaponData.itemName);
        }
        else
        {
            // ���� ����� �������� �����͸� �����ϰ� ��� ������Ʈ�� �����մϴ�.
            ItemSO dataToDrop = weapons[1].weaponData;
            DropUnselectedWeapon(weapons[1]);
            CreateDroppedWeapon(dataToDrop);
            // �� �Ŀ� �κ��丮 ������ �� ���������� ������Ʈ�մϴ�.
            Debug.Log("������ ���� " + weapons[1].weaponData.itemName);
            weapons[1] = newWeapon;
            Debug.Log("2���� �߰� " + newWeapon.weaponData.itemName);
        }

        if (ShowWeaponInventory.Instance != null)
        {
            ShowWeaponInventory.Instance.UpdateInventoryImage();
            OnWeaponChanged?.Invoke(newWeapon.weaponData);

        }
    }

    private void CreateDroppedWeapon(ItemSO dataToDrop)
    {
        // ����� ������ �������� ã���ϴ�.
        GameObject weaponPrefab = dataToDrop.prefab; 

        // ����� ������ �� �ν��Ͻ��� �����մϴ�.
        GameObject droppedWeaponObject = Instantiate(weaponPrefab, dropPoint.position, Quaternion.identity);

        // ��ӵ� �����ۿ� ���� PickupWeapon ������Ʈ�� �����մϴ�.
        PickupWeapon pickupComponent = droppedWeaponObject.GetComponent<PickupWeapon>();
        if (pickupComponent != null)
        {
            pickupComponent.weaponData = dataToDrop; 
        }
    }

    private void DropUnselectedWeapon(Weapon dropWeapon)
    {
        // �κ��丮���� ���⸦ �����մϴ�.
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
            Debug.Log("1����: " + weapons[0].name + "  2����: " + weapons[1].name);
            ShowWeaponInventory.Instance.UpdateInventoryImage();
            OnWeaponChanged?.Invoke(weapons[0].weaponData);
        }
    }


    public ItemSO GetWeaponInUse()
    {
        if(weapons[0] != null)
        {
            return weapons[0].weaponData;
        }
        else
        {
            return null;
        }
    }
}
