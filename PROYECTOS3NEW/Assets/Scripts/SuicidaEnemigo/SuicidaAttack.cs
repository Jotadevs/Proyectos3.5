using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidaAttack : MonoBehaviour
{
    private Transform player;
    private Transform player2;
    private SuicidaDetection SD;
    public float speed;
    private PatrolSuicida patroll;
    public SceneController sceneController;

    // Start is called before the first frame update
    private void Awake()
    {
        sceneController = GameObject.FindObjectOfType<SceneController>();
    }
    void Start()
    {
        SD = gameObject.GetComponent<SuicidaDetection>();

        if(sceneController.isSinglePlayer)
            player = GameObject.Find("Player").GetComponent<Transform>();
        else
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
            player2 = GameObject.Find("Player2").GetComponent<Transform>();
            

        }

        patroll = GetComponent<PatrolSuicida>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (SD.detected1)
        {
            patroll.speed = 0;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        if (SD.detected2)
        {
            patroll.speed = 0;
            transform.position = Vector3.MoveTowards(transform.position, player2.position, step);
        }
    }
  
}
