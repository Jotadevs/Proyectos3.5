using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidaAttack : MonoBehaviour
{
    public Transform player;
    public SuicidaDetection SD;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (SD.detected)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }
}
