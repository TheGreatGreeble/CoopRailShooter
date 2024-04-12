using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peaShooter : Weapon
{
    // Variables to define weapon behavior
    [SerializeField] public GameObject bullet;
    private Quaternion bulletRotation;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Shoot()
    {
        if (player == 1) {
            bulletRotation = gameObject.transform.rotation;
        }
        else {
            bulletRotation = gameObject.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        }
        Instantiate(bullet, gameObject.transform.position, bulletRotation);
    }
}

