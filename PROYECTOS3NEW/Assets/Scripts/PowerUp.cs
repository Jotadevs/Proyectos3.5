using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int powerUps = 0;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            powerUps++;
            Destroy(other.gameObject);
            Debug.Log(powerUps);
        }
    }
}
