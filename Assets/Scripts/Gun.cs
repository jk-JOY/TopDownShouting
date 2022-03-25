using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform muzzle;
    public Projectile projectile;
    public float msBetweenshots = 100f;
    public float muzzleVelocity = 35;

    public float nextShotTime;

    public void Shoot()
    {
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenshots / 1000;
            Projectile newprojectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newprojectile.SetSpeed(muzzleVelocity);
        }

    }
}
