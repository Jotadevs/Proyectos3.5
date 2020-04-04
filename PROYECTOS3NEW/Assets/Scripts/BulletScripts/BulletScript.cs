using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 2f;

    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_Timer);
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
