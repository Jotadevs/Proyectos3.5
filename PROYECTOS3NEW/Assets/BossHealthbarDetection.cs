using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthbarDetection : MonoBehaviour
{
    public bool showBar;
    public Transform healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StartPatrol")
        {
            Debug.Log("Oh shit");
            healthBar.position = new Vector3(0, -17f, -7f);
        }
    }
}
