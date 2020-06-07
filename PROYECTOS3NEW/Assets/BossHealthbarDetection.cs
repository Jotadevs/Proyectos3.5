using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthbarDetection : MonoBehaviour
{
    public bool showBar;
    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("BossHealthbar");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StartPatrol")
        {
            healthBar.SetActive(true);
        }
    }
}
