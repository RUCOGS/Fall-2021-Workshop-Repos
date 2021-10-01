using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0;

    public int bulletLifeTime;
    
    // Timer to keep track of when to despawn
    private Stopwatch lifetimeStopwatch = new Stopwatch();
    
    // Start is called before the first frame update
    void Start()
    {
        lifetimeStopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Move the bullet towards a position
        this.transform.Translate(new Vector3( 1, 0, 0) * Time.deltaTime * Speed);


        // When time is reached, destroy the bullet so its not infinetly in the scene
        if (lifetimeStopwatch.ElapsedMilliseconds > bulletLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    
    
    
    // If we hit something, destroy it and destroy ourselves.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        
        
        // TODO: You can add a way to get the enemy health and decrement it here
    }
}
