using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMoving : MonoBehaviour
{
    public float speed;
    public float timeCounter;
    public float limit;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= limit)
        {
            timeCounter = 0;
            speed *= -1f;
        }
        //this.transform.position = new Vector3(transform.position.x * speed, transform.position.y, transform.position.z);
        rb.velocity = new Vector3(transform.position.x * speed, transform.position.y, transform.position.z);
    }
}
