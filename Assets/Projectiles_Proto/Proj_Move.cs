using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proj_Move : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 vel_start = Vector3.forward * 20; // starting projectile velocity
    public Vector3 accel = Vector3.zero; // if not 0, adds to velocity every fixed update

    public bool destroyOnHit = true;
    private bool canAccel = true; // sets to false if there is no acceleration to add
    public float lifespan = 5; // number of seconds until projectile disappears

    public float damage = 5;

    // Start is called before the first frame update
    public virtual void Start() {
        if (rb != null) {
            // setup the velocity
            //rb.velocity = vel_start;
            rb.velocity = Vector3.zero;
            rb.AddRelativeForce(vel_start, ForceMode.VelocityChange);
            //rb.AddForce(vel_start, ForceMode.VelocityChange);
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
        damageEntity(other.gameObject);
    }

    public virtual void damageEntity(GameObject other) {
        Debug.Log("damage gameobject: " + other.name);
        MoveForward component = other.GetComponent<MoveForward>();
        if (component) {
            component.TakeDamage(5);
            GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().addScore(1);
            if (destroyOnHit) Destroy(gameObject);
        } else if (other.gameObject.tag == "Player") {
            Debug.Log("PLAYER KILLED");
            SceneManager.LoadScene(0);
            if (destroyOnHit) Destroy(gameObject);
        }
        
    }
}
