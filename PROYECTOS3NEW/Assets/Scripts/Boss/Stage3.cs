using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    public Rigidbody bullet;
    public BossDetection BD;
    public float fireRate;
    public float timeCounter;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= fireRate && BD.shoot)
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
