using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStats { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        CharacterSO characterSO = null;
        if (baseStats.characterSO != null)
        {
            characterSO = Instantiate(baseStats.characterSO);
        }

        CurrentStats = new CharacterStats { characterSO = characterSO };
        // TODO
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.maxStamina = baseStats.maxStamina;
        CurrentStats.spd = baseStats.spd;

    }
}