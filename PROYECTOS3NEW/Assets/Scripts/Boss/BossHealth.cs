using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int hpoint = 100;
    private GameObject healthbar;
    private void Start()
    {
        healthbar = GameObject.Find("BossHealthbar");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            hpoint -= 4;
            healthbar.SendMessage("TakeDamage", 4);
        }
    }
}
