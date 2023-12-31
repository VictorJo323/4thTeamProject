using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1, 100)] public int maxStamina;
    [Range(1f, 20f)] public float spd;

    public int atk;
    public int def;
    public float atksp;
    public CharacterSO characterSO;
}