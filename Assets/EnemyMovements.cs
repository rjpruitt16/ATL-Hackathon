﻿using UnityEngine;
using System.Collections;
using System;

public class EnemyMovements : MonoBehaviour
{
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Vector3 offset;
    Animator anim;                      // Reference to the animator component0.
    Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    //float camRayLength = 100f;
    public float speed = 2f;
    public int damage;
    Boolean foward = false;
    public GameObject player;
    public PlayerHealth health;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        damage = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset =  player.transform.position - transform.position;
        Console.WriteLine(offset);
        float h = (offset.x > 0) ? transform.position.x - speed: 
            transform.position.x + speed;
 
        // float v = Input.GetAxisRaw("Vertical");
        float v = 0f;

        Move(h, v);
        //Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void OnCollisionEnter2D(Collider other)
    {
        if (other.gameObject == player)
        {
            health.TakeDamage(damage);
        }
    }
    /*void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotatation);
        }
    }*/

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
