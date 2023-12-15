using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCharacterData", menuName = "DelegateTest/Character", order = 0)]

public class CharacterSO : ScriptableObject
{
    [Header("Character Info")]
    public string name;
    public int hp;
    public int atk;
    public int def;
    public float spd;
    public float atksp;
    public float crit;

}
