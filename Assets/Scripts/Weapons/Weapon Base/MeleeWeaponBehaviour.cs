using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//base script for all melee weapons
public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float destroyAfterSeconds;   

    //current Stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected float currentPierce;


    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CoolDownDuration;
        currentPierce = weaponData.Pierce;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); //we use current damage instead of weapon data damage because of damage multipliers that will be added later
        }
        else if(col.CompareTag("Prop"))
        {
            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
            }
        }
    }

}
