using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazaShooting : MonoBehaviour
{
    public Rigidbody bullet;
    public CazaDetection CD;
    public PassAwayDetection PAD;
    public float fireRate;
    public float timeCounter;
    public float bulletSpeed;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (CD.shoot && timeCounter >= fireRate && PAD.canShoot)
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
