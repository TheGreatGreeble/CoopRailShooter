using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peaShooter : Weapon
{
    // Variables to define weapon behavior

    //OVERRIDE THIS VARIABLE TO THE PROJECTILE BEING SHOT IN WEAPON SCRIPTS
    public new GameObject bullet;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Shoot()
    {
        //Instantiate(bullet, self.transform.position, self.transform.rotation);
    }
}

