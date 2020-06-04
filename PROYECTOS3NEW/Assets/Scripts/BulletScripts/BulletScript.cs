using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 2f;
    public Score newScore;
    public int scoreValue;
    public Transform explosion;

    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_Timer);
        newScore = GameObject.Find("ScoreText").GetComponent<Score>();
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

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            col.gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
            scoreValue = 10;
        }
        if (col.gameObject.tag == "Enemy2")
        {
            Destroy(gameObject);
            col.gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
            scoreValue = 50;

        }
        if (col.gameObject.tag == "Enemy3")
        {
            Destroy(gameObject);
            col.gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
            scoreValue = 100;
        }
        newScore.AddScore(scoreValue);
    }
}
