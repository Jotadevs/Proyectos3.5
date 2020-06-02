using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookAtPlayer : MonoBehaviour
{
    public Transform player;
    //public Transform originalRotation;
    public TurretDetection TR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TR.detected)
        transform.LookAt(player, Vector3.up);
    
    }
}
