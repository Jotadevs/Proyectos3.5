using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public MissileAttack mAttack;
    // Start is called before the first frame update
    void Start()
    {
        mAttack = GameObject.FindObjectOfType<MissileAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += mAttack.mSpeed * Time.deltaTime;
        temp.y -= mAttack.mSpeed * Time.deltaTime;
        transform.position = temp;
    }
}
