using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base script for all weapon controllers
[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName ="ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public GameObject prefab;
    //base starts for weapons
    public float damage;
    public float speed;
    public float coolDownDuration;
    float currentCooldown;
    public int pierce;
}
