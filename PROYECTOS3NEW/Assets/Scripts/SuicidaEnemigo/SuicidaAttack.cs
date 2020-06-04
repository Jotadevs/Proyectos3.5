using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidaAttack : MonoBehaviour
{
    private Transform player;
    private SuicidaDetection SD;
    public float speed;
    private patrol patroll;

    // Start is called before the first frame update
    void Start()
    {
        SD = gameObject.GetComponent<SuicidaDetection>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        patroll = GetComponent<patrol>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (SD.detected)
        {
            patroll.speed = 0;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }
  
}
