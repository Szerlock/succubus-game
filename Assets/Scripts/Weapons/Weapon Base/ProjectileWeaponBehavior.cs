using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base script of all projectile behaviours [to be placed on a prefab of a weapon that is a projectile]
public class ProjectileWeaponBehavior : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;

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

            transform.localScale = scale;
            transform.rotation = Quaternion.Euler(rotation); // check video 3 vampire survivors
        }
    }
}
