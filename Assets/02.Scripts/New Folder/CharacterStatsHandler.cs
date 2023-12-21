using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    public CharacterSO baseStats; 
    /// <summary>
    /// /////////
    /// </summary>
    public CharacterStats CurrentStats { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();
    public WeaponInventory weaponInventory;


    private void Awake()
    {
        if (weaponInventory != null)
        {
            weaponInventory.OnWeaponChanged += UpdateStatsWithWeapon;
        }
        UpdateCharacterStats();
    }

    private void UpdateStatsWithWeapon(ItemSO weaponData)
    {
        ResetToBaseStats();

        CurrentStats.atk += weaponData.str;
        CurrentStats.def += weaponData.def;
        CurrentStats.spd += weaponData.spd;
        CurrentStats.atksp += weaponData.atksp;
        CurrentStats.maxHealth += weaponData.hp;
    }

    private void ResetToBaseStats()
    {
        CurrentStats.maxHealth = baseStats.hp;
        CurrentStats.maxStamina = baseStats.stamina;
        CurrentStats.atk = baseStats.atk;
        CurrentStats.def = baseStats.def;
        CurrentStats.spd = baseStats.spd;
        CurrentStats.atksp = baseStats.atksp;
    }

    private void UpdateCharacterStats()
    {
        CurrentStats = new CharacterStats
        {
            maxHealth = baseStats.hp,
            maxStamina = baseStats.stamina,
            atk = baseStats.atk,
            def = baseStats.def,
            spd = baseStats.spd,
            atksp = baseStats.atksp
        };

        
        foreach (var modifier in statsModifiers)
        {
            CurrentStats.maxHealth += modifier.maxHealth;
            CurrentStats.maxStamina += modifier.maxStamina;
            CurrentStats.spd += modifier.spd;
            CurrentStats.atk += modifier.atk;
            CurrentStats.def += modifier.def;
            CurrentStats.atksp += modifier.atksp;
        }
    }
}