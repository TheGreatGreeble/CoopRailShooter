using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade_Proj : Proj_Move
{
    public GameObject explosion;

    public override void damageEntity(GameObject other) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("exploding!!!");
        Destroy(gameObject);
    }
}
