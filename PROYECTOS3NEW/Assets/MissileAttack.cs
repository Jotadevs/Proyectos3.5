using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAttack : MonoBehaviour
{
    public Transform mPoint;
    public GameObject missilePrefab;
    public int mSpeed;
    public float misileTimer = 0.35f;
    private float current_MisileTimer;
    bool canMisile;



    public void MissileShoot()
    {
        misileTimer += Time.deltaTime;
        if (misileTimer > current_MisileTimer)
        {
            canMisile = true;

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (canMisile)//SimpleAttack
            {
                canMisile = false;
                misileTimer = 0;
                Instantiate(missilePrefab, mPoint.position, Quaternion.identity);
            }
        }

        
    }
    
}
