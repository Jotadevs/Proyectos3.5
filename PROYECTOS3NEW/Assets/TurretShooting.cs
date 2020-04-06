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
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        clone.velocity = transform.TransformDirection(Vector3.down * 2);
        Destroy(clone.gameObject, 5);
    }
}
