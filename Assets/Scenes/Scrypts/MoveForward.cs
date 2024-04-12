using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody))]
public class MoveForward : MonoBehaviour
{
    public bool active = false;
    public float speed = 0.5f;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private int health;

    void Start()
    {
        // Attempt to get the MeshRenderer component
        health = 10;
        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.enabled = false; // Optionally disable MeshRenderer on start


        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (active)
        {
            meshRenderer.enabled = true;
            // Moves the character forward continuously using physics
            rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
            checkAlive();
        }
    }

    public void Activate(float speedIn)
    {
        
        speed = speedIn;
        active = true;
        
    }

    public void TakeDamage(int x){
        health -= x;
        checkAlive();
    }

    void checkAlive(){
        if (health <= 0){
            Destroy(gameObject);
        }
        if (Math.Abs(transform.position.z) <= 2)
            {
                Destroy(gameObject); // Destroy the GameObject
        }
    }
}