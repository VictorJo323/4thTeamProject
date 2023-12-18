using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWeaponInventory : MonoBehaviour
{
    public WeaponInventory weaponInventory;
    public Image weaponSlot1;
    public Image weaponSlot2;
    void Update()
    {
        UpdateInventoryImage();
    }

    private void UpdateInventoryImage()
    {
        if (weaponInventory.weapons[0] != null)
        {
            weaponSlot1.sprite = weaponInventory.weapons[0].weaponData.icon;
            weaponSlot1.enabled = true;
        }
        else
        {
            weaponSlot1.enabled = false;
        }

        if(weaponInventory.weapons[1] != null)
        {
            weaponSlot2.sprite = weaponInventory.weapons[1].weaponData.icon;
            weaponSlot2.enabled = true;
        }
        else
        {
            weaponSlot2.enabled = false;
        }
    }
}