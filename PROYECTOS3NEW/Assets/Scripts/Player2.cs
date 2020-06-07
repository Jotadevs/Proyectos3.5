using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //Movimiento
    public float speed = 5f;
    public float min_Y, max_Y, min_X, max_X;
    [SerializeField]
    public GameObject player_Bullet;
    public GameObject laser_Bullet;
    [SerializeField]
    public Transform attack_Point;
    public Transform laser_Point;
    public Transform attack2_Point;
    public Transform attack3_Point;
    public float attack_Timer = 0.35f;
    private float current_attack_Timer;
    bool misileOn;
    //Cosas del Dash
    private Rigidbody rb;
    public float dashSpeed;//velocidad del esquivo del dash
    private float dashTime;//Tiempo de ejecución del dash
    public float startDashTime;//Tiempo que tarda el dash
    public int direction = 0;

    //Activación de ataques.
    private bool canAttack;
    private bool misileShoot;//O crear un objeto de la clase stats.
    private bool canMisile;
    private bool canDoubleShoot;
    private bool canLaser;
    private bool canDash;

    public MissileAttack missile;
    public PowerUp pUp;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        current_attack_Timer = attack_Timer;
        dashTime = startDashTime;
    }

    void Update()
    {
        MovePlayer();
        Attack();
        applyPowerUp();

        //  Debug.Log(speed);
        // Debug.Log(playerstats.powerUps);
        //  Debug.Log(direction);

    }
    void FixedUpdate()
    {
        Dashing();
    }
    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
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
        else if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKey(KeyCode.RightArrow))
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
        else if (Input.GetKey(KeyCode.LeftArrow))
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
            canAttack = false;
            attack_Timer = 0;
            if (canDoubleShoot)
            {
                Instantiate(player_Bullet, attack2_Point.position, Quaternion.identity);
                Instantiate(player_Bullet, attack3_Point.position, Quaternion.identity);
            }
            else
            {
                if (canLaser)
                {
                    Instantiate(laser_Bullet, laser_Point.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (misileShoot)
            {
             
                if (misileOn)
                {
                    missile.MissileShoot();
                }
            }
        }
    }
    void Dashing()
    {
        if (direction == 0)
        {

            if (Input.GetAxisRaw("Vertical") > 0)
            {

                direction = 1;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                direction = 2;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 3;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = 4;
            }

        }//AQUIESTABN
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                //rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.I))
                {
                    if (direction == 1)
                    {
                        Vector3 impulse = transform.position;
                        impulse.y += dashSpeed * Time.deltaTime;
                        transform.position = impulse;

                        Debug.Log("ARRIBA HOSTIA");
                    }
                    if (direction == 2)
                    {
                        Vector3 impulse = transform.position;
                        impulse.y -= dashSpeed * Time.deltaTime;
                        transform.position = impulse;
                    }
                    if (direction == 3)
                    {
                        Vector3 impulse = transform.position;
                        impulse.x += dashSpeed * Time.deltaTime;
                        transform.position = impulse;
                    }
                    if (direction == 4)
                    {

                        Vector3 impulse = transform.position;
                        impulse.x -= dashSpeed * Time.deltaTime;
                        transform.position = impulse;
                    }
                }
            }
        }
    }
    void applyPowerUp()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pUp.powerUps == 1)//speed up donete
            {
                pUp.powerUps = 0;
                if (speed < 30f)
                {
                    //Insertar sonido de speedup
                    //Insertar fx de speedUp
                    speed = speed + 2f;
                }
            }
            if (pUp.powerUps == 2)
            {
                misileOn = true;
                pUp.powerUps = 0;
            }
            if (pUp.powerUps == 3)
            {
                canDoubleShoot = true;
                pUp.powerUps = 0;
                canLaser = false;
            }
            if (pUp.powerUps == 4)
            {
                canLaser = true;
                pUp.powerUps = 0;
                canDoubleShoot = false;
            }
            //igual pal doble
            // igual pal laser. el laser es que te apaga el ataque normal y el doble ataque y tienes un laser si lo mejoras tienes laser doble
            //El puto radial hay que mirarlo bien
        }
    }
}

