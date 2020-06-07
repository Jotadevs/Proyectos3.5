using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Vidas vidaCanvas;
    public BossDetection BD;
    public CazaDetection[] CD;
    public SuicidaDetection[] SD;
    public TurretDetection[] TD;
    public TurretLookAtPlayer[] TLP;
    public TurretShooting[] TS;
    public CazaShooting[] CS;
    public SuicidaAttack[] SA;
    public BulletScript bScript;
    public MeshRenderer mesh;
    public BDDController BDD;
    public int vida = 3;
    public InstantiateController controller;
    public stagemove stage;
    public Score score;
    public List<Vector3> checkpoints;
    public GameObject escenario;
    private GameObject[] bullets;
    public Transform explosion;
    void Start()
    {
        SA = GameObject.FindObjectsOfType<SuicidaAttack>();
        CS = GameObject.FindObjectsOfType<CazaShooting>();
        TS = GameObject.FindObjectsOfType<TurretShooting>();
        TLP = GameObject.FindObjectsOfType<TurretLookAtPlayer>();
        SD = GameObject.FindObjectsOfType<SuicidaDetection>();
        CD = GameObject.FindObjectsOfType<CazaDetection>();
        TD = GameObject.FindObjectsOfType<TurretDetection>();
        BD = GameObject.FindObjectOfType<BossDetection>();  
        BDD = GameObject.FindObjectOfType<BDDController>();
        vidaCanvas = GameObject.FindObjectOfType<Vidas>();
        stage = GameObject.FindObjectOfType<stagemove>();
        score = GameObject.FindObjectOfType<Score>();
        bScript = GameObject.FindObjectOfType<BulletScript>();
    }

    void Update()
    {
        escenario = GameObject.FindObjectOfType<stagemove>().gameObject;
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            BD.enabled = false;
            for (int i = 0; i < CD.Length; i++)
            {
                CD[i].enabled = false;
            }
            for (int i = 0; i < SD.Length; i++)
            {
                SD[i].enabled = false;
            }
            for (int i = 0; i < TD.Length; i++)
            {
                TD[i].enabled = false;
            }
            for (int i = 0; i < TLP.Length; i++)
            {
                TLP[i].enabled = false;
            }
            for (int i = 0; i < TS.Length; i++)
            {
                TS[i].enabled = false;
            }
            for (int i = 0; i < CS.Length; i++)
            {
                CS[i].enabled = false;
            }
            for (int i = 0; i < SA.Length; i++)
            {
                SA[i].enabled = false;
            }
            Instantiate(explosion, transform.position, transform.rotation);
            mesh.enabled = false;
            vida -= 1;
            if (vida == 0)
            {
                StartCoroutine(ChangeScene());
            }
            else if (vida >= 0)
                vidaCanvas.CambioVida(vida);
            StartCoroutine(GoToCheckPoint());  
        }
        
    }

    void SelectLastCheckpoint(List<Vector3> checkpoints)
    {
        if (escenario.transform.position.x < checkpoints[4].x)
        {
            escenario.transform.position = new Vector3(checkpoints[4].x, checkpoints[4].y, 0);
        }
        if (escenario.transform.position.x > checkpoints[4].x && escenario.transform.position.x < checkpoints[3].x)
        {
            escenario.transform.position = new Vector3(checkpoints[3].x, checkpoints[3].y, 0);
        }
        else if (escenario.transform.position.x > checkpoints[3].x && escenario.transform.position.x < checkpoints[2].x)
        {
            escenario.transform.position = new Vector3(checkpoints[2].x, checkpoints[2].y, 0);
        }
        else if (escenario.transform.position.x > checkpoints[2].x && escenario.transform.position.x < checkpoints[1].x)
        {
            escenario.transform.position = new Vector3(checkpoints[1].x, checkpoints[1].y, 0); //restar 1 a cadaresunbtado
        }
        else if (escenario.transform.position.x > checkpoints[1].x && escenario.transform.position.x < checkpoints[0].x)
        {
            escenario.transform.position = new Vector3(checkpoints[0].x, checkpoints[0].y, 0);
        }
        if (escenario.transform.position.x > checkpoints[0].x)
        {
            escenario.transform.position = new Vector3(checkpoints[0].x, checkpoints[0].y, 0);
        }
    }

    IEnumerator GoToCheckPoint()
    {
        
        yield return new WaitForSeconds(3);
        SelectLastCheckpoint(checkpoints);
        stage.speed = 7;
        controller.InstanceMyObjects();
        mesh.enabled = true;
        BD.enabled = true;
        for (int i = 0; i < CD.Length; i++)
        {
            CD[i].enabled = true; 
        }
        for (int i = 0; i < SD.Length; i++)
        {
            SD[i].enabled = true;
        }
        for (int i = 0; i < TD.Length; i++)
        {
            TD[i].enabled = true;
        }
        for (int i = 0; i < TLP.Length; i++)
        {
            TLP[i].enabled = true;
        }
        for (int i = 0; i < TS.Length; i++)
        {
            TS[i].enabled = true;
        }
        for (int i = 0; i < CS.Length; i++)
        {
            CS[i].enabled = true;
        }
        for (int i = 0; i < SA.Length; i++)
        {
            SA[i].enabled = true;
        }
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }

    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        score.UpdateDatabase(vida, "'Looser'");
        Debug.Log("CambiaEscena");
        SceneManager.LoadScene("Gameover");
  
    }

}
