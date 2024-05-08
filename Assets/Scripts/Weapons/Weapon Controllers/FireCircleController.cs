using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircleController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Attact()
    {
        base.Attact();
        GameObject spanwedCircle = Instantiate(weaponData.prefab);
        spanwedCircle.transform.position = transform.position; //when the cirle is spawed the assigns position to be the same as the players position
        spanwedCircle.transform.parent = transform; // so its spawns below object
    }
}
