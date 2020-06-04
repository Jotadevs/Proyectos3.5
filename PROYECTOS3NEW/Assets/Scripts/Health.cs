using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Vidas vidaCanvas;
    public int vida = 3;
    public InstantiateController controller;
    public List<Vector3> checkpoints;
    public GameObject escenario;
    void Start()
    {
        vidaCanvas = GameObject.FindObjectOfType<Vidas>();
    }

    void Update()
    {
        escenario = GameObject.FindObjectOfType<stagemove>().gameObject;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            vida -= 1;
            if(vida >= 0)
                vidaCanvas.CambioVida(vida);
            SelectLastCheckpoint(checkpoints);
            controller.InstanceMyObjects();
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



       /*
        for (int i = 4; i < checkpoints.Count; i--)
        {
            if(i == 0)
            {
                if (GetComponentInParent<PlayerController>().gameObject.transform.position.x < checkpoints[0].x)
                    escenario.transform.position = new Vector3(checkpoints[0].x, checkpoints[i].y, 0);
                else
                    break;
            }
            else if (GetComponentInParent<PlayerController>().gameObject.transform.position.x < checkpoints[i].x && GetComponentInParent<PlayerController>().gameObject.transform.position.x > checkpoints[i - 1].x) //
            {
                escenario.transform.position = new Vector3(checkpoints[i].x, checkpoints[i].y, 0);
            }
        }*/
    }

}
