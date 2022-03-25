using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public void SetSpeed(float newspeed)
    {
        speed = newspeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

}
