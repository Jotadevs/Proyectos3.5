using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidaDetection : MonoBehaviour
{
    public float range;
    public Transform player;
    public bool shooting;
    public bool detected;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            shooting = true;
            detected = true;
        }
        else
        {
            shooting = false;
            detected = false;
        }
    }
}
