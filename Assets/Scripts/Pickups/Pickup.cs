using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")) //close to player it gets destroyed
        {
            Destroy(gameObject);
        }
    }
}
