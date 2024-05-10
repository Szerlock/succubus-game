using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attact()
    {
        base.Attact();
        GameObject spawnedKnife = Instantiate(weaponData.Prefab);
        spawnedKnife.transform.position = transform.position; // assing the position
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(pm.lastMovedVector); // Reference and set the direction
    }
}
