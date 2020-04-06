using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 1;
    public float shield = 3;
    bool shield_On = false;
    public float powerUps = 0;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(powerUps);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUps++;
            
        }
    }
    //Para la velocidad, la inicial está en 5. SI hace speedup, if speed<10 powerUps=0; speed =speed+1.5f; 

   
    
}
