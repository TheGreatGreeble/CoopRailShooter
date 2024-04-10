using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_Move : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 vel_start = Vector3.forward * 20;
    public Vector3 accel = Vector3.zero;
    private bool canAccel = true;
    public float lifespan = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (rb != null) {
            rb.velocity = vel_start;
            if (accel == Vector3.zero) {
                canAccel = false;
            }
        } else {
            Debug.LogError("Projectile: " + name + " has no rigidbody");
        }

        StartCoroutine("KillProj", lifespan);
    }

    private void FixedUpdate() {
        if (rb != null && canAccel) {
            rb.AddForce(accel,ForceMode.VelocityChange);
        }
    }

    private IEnumerator KillProj(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
