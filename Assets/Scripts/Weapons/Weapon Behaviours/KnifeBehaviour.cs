using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehavior
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += direction * weaponData.speed * Time.deltaTime; // set movement for knife
    }
}
