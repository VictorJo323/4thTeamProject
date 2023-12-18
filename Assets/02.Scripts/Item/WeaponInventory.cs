using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private Weapon[] weapons = new Weapon[2];
    public ItemDatabase itemDatabase;
    public Transform dropPoint;

    public void AddWeapon(Weapon newWeapon)
    {
        if(weapons[0] == null)
        {
            weapons[0] = newWeapon;
        }
        else if(weapons[1] == null)
        {
            weapons[1] = newWeapon;
        }
        else
        {
            DropUnselectedWeapon(weapons[1]);
            weapons[1] = newWeapon;
        }
    }

    private void DropUnselectedWeapon(Weapon dropWeapon)
    {
        dropWeapon.gameObject.SetActive(true);
        dropWeapon.transform.position = dropPoint.position;
    }
}
