using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movimiento
    public float speed = 5f;
    public float min_Y, max_Y, min_X, max_X;
    [SerializeField]
    public GameObject player_Bullet;
    [SerializeField]
    public Transform attack_Point;
    public PlayerStats playerstats;
    public float attack_Timer = 0.35f;
    private float current_attack_Timer;

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



    void Awake()
    {
        playerstats = GetComponent<PlayerStats>();
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
            if (canAttack)//SimpleAttack
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
                
                if (Input.GetKeyDown(KeyCode.R))
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
                    if(direction == 4)
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

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (playerstats.powerUps == 1)//speed up donete
            {
                playerstats.powerUps = 0;
                if (speed < 12f)
                {
                    //Insertar sonido de speedup
                    //Insertar fx de speedUp
                    speed = speed + 2f;

                }
            }
            if (playerstats.powerUps == 2)
            {
                canMisile = true;
            }
            //igual pal doble
            // igual pal laser. el laser es que te apaga el ataque normal y el doble ataque y tienes un laser si lo mejoras tienes laser doble
            //El puto radial hay que mirarlo bien

        }
    }
}

