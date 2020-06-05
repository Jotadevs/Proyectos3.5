using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAttack : MonoBehaviour
{
    public Transform mPoint;
    public GameObject missilePrefab;
    public int mSpeed;

    

    public void MissileShoot()
    {
        Instantiate(missilePrefab, mPoint.position , Quaternion.identity);
        
    }
    
}
