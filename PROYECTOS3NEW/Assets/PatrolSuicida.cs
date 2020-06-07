using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSuicida : MonoBehaviour
{
    public float speed;
    public Transform[] movePositions;
    public EnemyList lista;
    private int randomSpot;
    private float WaitTime;
    public float startWaitTime;

    void Start()
    {
        lista = GameObject.FindObjectOfType<EnemyList>();
        WaitTime = startWaitTime;
        randomSpot = Random.Range(0, movePositions.Length);
        lista.AddOtakus(this.gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePositions[randomSpot].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePositions[randomSpot].position) < 0.2f)
        {
            if (WaitTime <= 0)
            {
                randomSpot = Random.Range(0, movePositions.Length);
                WaitTime = startWaitTime;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StartPatrol")
        {
            speed = 7;
        }
    }

}

