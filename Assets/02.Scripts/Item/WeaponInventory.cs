using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private Weapon[] weapons = new Weapon[2];

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
            return;
        }
    }
}
