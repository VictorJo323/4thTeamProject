using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "Ranged", order = 1)]
public class RangedAttackData : CharacterSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;
    public string bulletNameTag2;
    public float duration;
    public float spread;
    public int numberofProjectilesPerShot;
    public float multipleProjectilesAngel;
    public Color projectileColor;
    public float speed;
    public float size;
}
