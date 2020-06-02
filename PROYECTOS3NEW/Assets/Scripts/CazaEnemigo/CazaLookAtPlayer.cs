using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazaLookAtPlayer : MonoBehaviour
{
    public Transform player;
    //public Transform originalRotation;
    public CazaDetection CD;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CD.detected)
            transform.LookAt(player, Vector3.up);

    }
}
