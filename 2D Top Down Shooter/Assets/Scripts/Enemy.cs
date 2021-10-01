using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D enemyRigidbody;

    public Transform player;

    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Apply force towards the direction of the player
        this.enemyRigidbody.AddForce((Vector2)(player.position - this.transform.position) * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //We lost the game if the ghost collides with the player.
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Game Lost!");
            Time.timeScale = 0;
        }
    }
}
