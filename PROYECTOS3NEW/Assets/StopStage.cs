using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopStage : MonoBehaviour
{
    public stagemove stage;
    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.FindObjectOfType<stagemove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stage")
        {
            Debug.Log("Entra");
            stage.speed = 0;
        }
    }
}
