using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

// base script of all projectile behaviours [to be placed on a prefab of a weapon that is a projectile]
public class ProjectileWeaponBehavior : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

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

    // Update is called once per frame
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry == 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); // check video 3 vampire survivors
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); //we use current damage instead of weapon data damage because of damage multipliers that will be added later
            ReducePierce();
        }
        else if(col.CompareTag("Props"))
        {
            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                ReducePierce();
            }
        }
    }

    void ReducePierce() //Destroy when pierce is 0
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }

}
