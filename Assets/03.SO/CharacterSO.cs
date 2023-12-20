using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DCD", menuName = "Character", order = 0)]

public class CharacterSO : ScriptableObject
{
    [Header("Character Info")]
    public string charName;
    public int hp;
    public int stamina;
    public int atk;
    public int def;
    public float spd;
    public float atksp;
    public float crit;
    public LayerMask target;

    [Header("Knock Back Info")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;

}
