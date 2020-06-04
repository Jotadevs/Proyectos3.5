using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazaDetection : MonoBehaviour
{
    public float range;
    public Transform player;
    public Transform player2;
    public bool shoot;
    public bool shooting1;
    public bool detected1;
    public bool shooting2;
    public bool detected2;
    public SceneController sceneController;

    private void Awake()
    {
        sceneController = GameObject.FindObjectOfType<SceneController>();
    }
    private void Start()
    {
        if (sceneController.isSinglePlayer)
            player = GameObject.Find("Player").GetComponent<Transform>();
        else
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
            player2 = GameObject.Find("Player2").GetComponent<Transform>();

        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            shooting1 = true;
            detected1 = true;
            shooting2 = false;
            detected2 = false;
            shoot = true;
        }
        else
        {
            shooting1 = false;
            detected1 = false;
            shooting2 = false;
            detected2 = false;
            shoot = false;
        }


        if (!sceneController.isSinglePlayer)
        {
            if (Vector3.Distance(player2.position, transform.position) <= range)
            {
                shooting2 = true;
                detected2 = true;
                shooting1 = false;
                detected1 = false;
                shoot = true;
            }
            else
            {
                shooting1 = false;
                detected1 = false;
                shooting2 = false;
                detected2 = false;
                shoot = false;
            }
        }
    }
}
