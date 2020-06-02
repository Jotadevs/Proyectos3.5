using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretShooting : MonoBehaviour
{
    
    public Rigidbody bullet;
    public TurretDetection TR;
    public float fireRate;
    public float timeCounter;
    public float bulletSpeed;
    

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (TR.shooting && timeCounter >= fireRate)
        {
            timeCounter = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Rigidbody clone = Instantiate(bullet, transform.position, Quaternion.identity);
        clone.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
        Destroy(clone.gameObject, 5);
    }
}
