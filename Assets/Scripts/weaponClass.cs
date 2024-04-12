using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Variables to define weapon behavior
    public float fireRate = 1f;
    public float range = 100f;
    public float damage = 50f;

    [SerializeField] public int player;

     //OVERRIDE THIS VARIABLE TO THE PROJECTILE BEING SHOT IN WEAPON SCRIPTS
     public GameObject baseBullet;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    public virtual void Update()
    {
        // Check if it's time to fire
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        
    }
}
