using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Vidas vidaCanvas;
    public int vida = 3;
    // Start is called before the first frame update
    void Start()
    {
        vidaCanvas = GameObject.FindObjectOfType<Vidas>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            vida -= 1;
            vidaCanvas.CambioVida(vida);
        }
        
    }
}
