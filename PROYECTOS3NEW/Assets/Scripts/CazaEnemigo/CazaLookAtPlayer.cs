using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazaLookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Transform player2;
    //public Transform originalRotation;
    public CazaDetection CD;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CD.detected1)
            transform.LookAt(player, Vector3.up);
        else if (CD.detected2)
        {
            transform.LookAt(player2, Vector3.up);
        }

    }
}
