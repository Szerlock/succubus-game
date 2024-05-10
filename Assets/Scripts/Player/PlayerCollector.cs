using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerCollector;
    public float pullSpeed;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        playerCollector.radius = player.currentMagnet;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //this checks if the other object has icollectible
        if(col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //"pulling animation"
            //Gets the rigidbody2s comp of the item
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            //just a vector pointing to the player 
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            //applies force to the item 
            rb.AddForce(forceDirection * pullSpeed);

            // if it does call collect method
            collectible.Collect();
        }
    }
}
