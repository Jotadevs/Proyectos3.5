using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float min_Y, max_Y, min_X, max_X;
    [SerializeField]
    public GameObject player_Bullet;
    [SerializeField]
    public Transform attack_Point;
    public PlayerStats playerstats;
    public float attack_Timer = 0.35f;
    private float current_attack_Timer;
    private bool canAttack;
    private bool misileShoot;//O crear un objeto de la clase stats.

    void Awake()
    {
        playerstats = GetComponent<PlayerStats>();
    }
    void Start()
    {
        current_attack_Timer = attack_Timer;
    }


    void Update()
    {
        MovePlayer();
        Attack();
    }
    void MovePlayer()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y > max_Y)
            {
                temp.y = max_Y;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;
            if (temp.y < min_Y)
            {
                temp.y = min_Y;
            }
            transform.position = temp;

        }
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x > max_X)
            {
                temp.x = max_X;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
            if (temp.x < min_X)
            {
                temp.x = min_X;
            }
            transform.position = temp;

        }
    }
    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_attack_Timer)
        {
            canAttack = true;

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = 0;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (misileShoot)
            {
                //misileshoot false
                //misile_timer=0;
                //Instantiate(player_misile, misile_point.position, quaternion.identity);
                //Hay que hacer un script para el misil como con la bala
            }
        }
    }
}

