using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;


// Extra Topics
// Object Pooling
// Health System
// Physics Bullets via Raycast
// Coroutines

public class PlayerMovement : MonoBehaviour
{

    public float Speed;

    public GameObject bulletPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        // Move the player
        
        Vector3 movement = Vector3.zero;
        
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;
        }
        
        this.transform.position += (movement * Time.deltaTime * Speed);
        
        
        //Look at our mouse!

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Rotation value calculations
        float rotationRadians = Mathf.Atan2(mousePosition.y - this.transform.position.y, mousePosition.x
            - this.transform.position.x);

        float rotiationDegrees = Mathf.Rad2Deg * rotationRadians;

        this.transform.eulerAngles = new Vector3(0, 0, rotiationDegrees);
        
        
        //Shooting!


        // When the player left clicks, a bullet will be spawned and oriented towards the mouse
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bulletPrefab);

            bulletObject.transform.position = this.transform.position;
            
            bulletObject.transform.eulerAngles = new Vector3(0, 0, rotiationDegrees);
        }
    }
}
