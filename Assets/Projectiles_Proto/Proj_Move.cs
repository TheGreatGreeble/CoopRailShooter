using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_Move : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 vel_start = Vector3.forward * 20; // starting projectile velocity
    public Vector3 accel = Vector3.zero; // if not 0, adds to velocity every fixed update
    private bool canAccel = true; // sets to false if there is no acceleration to add
    public float lifespan = 5; // number of seconds until projectile disappears

    // Start is called before the first frame update
    void Start() {
        if (rb != null) {
            // setup the velocity
            rb.velocity = vel_start;
            if (accel == Vector3.zero) {
                canAccel = false;
            }
        } else {
            Debug.LogError("Projectile: " + name + " has no rigidbody");
        }

        // set the projectile to die after [lifespan] seconds
        StartCoroutine("KillProj", lifespan);
    }

    private void FixedUpdate() {
        if (rb != null && canAccel) {
            // update velocity to add custom acceleration
            rb.AddForce(accel,ForceMode.VelocityChange);
        }
    }

    // kills the projectile after waitTime
    private IEnumerator KillProj(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    // collision detection for projectile
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Killable") {
            // KILL KILL KILL
            Destroy(other.gameObject);
        }
    }
}