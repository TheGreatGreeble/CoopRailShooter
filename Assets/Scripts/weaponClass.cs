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
    private Quaternion bulletRotation;
    public virtual void Start() {
    }
    // Update is called once per frame
    public virtual void Update()
    {
        // Check if it's time to fire
        if (Input.GetKeyDown(KeyCode.W) && player == 2 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && player == 1 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        if (player == 1) {
            bulletRotation = gameObject.transform.rotation;
        }
        else {
            bulletRotation = gameObject.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        }

        //spawn bullet
        Instantiate(baseBullet, gameObject.transform.position, bulletRotation);
    }
}
