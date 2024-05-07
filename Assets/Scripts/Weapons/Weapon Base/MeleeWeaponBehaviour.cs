using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//base script for all melee weapons
public class MeleeWeaponBehaviour : MonoBehaviour
{

    public float destroyAfterSeconds;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

}
