using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum Type
{
    MeleeWeapon,
    RangedWeapon,
    Armor,
    Consumable,
    Legacy
}

[CreateAssetMenu(fileName = "Item_", menuName = "Item/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    [Header("Feature")]
    public GameObject prefab;
    public string itemName;
    public Sprite icon;
    public string description;
    public int price;
    public Type itemType;
    public bool isStackable;
    public bool isUnique;
    public int maxQuantity;
    public int itemID;


    [Header("Stat")]
    public int hp;
    public int str;
    public int def;
    public float spd;
    public float atksp;
    public float crit;
    public float atkRange;
}
