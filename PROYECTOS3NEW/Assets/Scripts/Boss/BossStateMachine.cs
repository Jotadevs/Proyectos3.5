using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossStateMachine : MonoBehaviour
{
    public BossHealth bHealth;
    public Stage1 stage1;
    public Stage2 stage2;
    public Stage3 stage3;



    // Start is called before the first frame update
    void Start()
    {
        try
        {
            bHealth = GameObject.FindObjectOfType<BossHealth>();
            stage1 = GetComponent<Stage1>();
            stage2 = GetComponent<Stage2>();
            stage3 = GetComponent<Stage3>();
        }
        catch
        {
            bHealth = GameObject.FindObjectOfType<BossHealth>();

            stage2 = GetComponent<Stage2>();
            stage3 = GetComponent<Stage3>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (bHealth.hpoint <= 100 && bHealth.hpoint >= 70)
            {
                GetComponent<Stage1>().enabled = true;
                GetComponent<Stage2>().enabled = false;
                GetComponent<Stage3>().enabled = false;
            }
            if (bHealth.hpoint <= 70 && bHealth.hpoint >= 40)
            {
                GetComponent<Stage1>().enabled = false;
                GetComponent<Stage2>().enabled = true;
                GetComponent<Stage3>().enabled = false;
            }
            else if (bHealth.hpoint <= 40 && bHealth.hpoint > 0)
            {
                GetComponent<Stage1>().enabled = false;
                GetComponent<Stage2>().enabled = false;
                GetComponent<Stage3>().enabled = true;
            }
            if (bHealth.hpoint == 0)
            {
                GetComponent<Stage1>().enabled = false;
                GetComponent<Stage2>().enabled = false;
                GetComponent<Stage3>().enabled = false;
                SceneManager.LoadScene("YouWin");
            }
        }
        catch
        {
            if (bHealth.hpoint <= 100 && bHealth.hpoint >= 70)
            {
                
                GetComponent<Stage2>().enabled = false;
                GetComponent<Stage3>().enabled = false;
            }
            if (bHealth.hpoint <= 70 && bHealth.hpoint >= 40)
            {
                
                GetComponent<Stage2>().enabled = true;
                GetComponent<Stage3>().enabled = false;
            }
            else if (bHealth.hpoint <= 40 && bHealth.hpoint > 0)
            {
                
                GetComponent<Stage2>().enabled = false;
                GetComponent<Stage3>().enabled = true;
            }
            if (bHealth.hpoint == 0)
            {
                
                GetComponent<Stage2>().enabled = false;
                GetComponent<Stage3>().enabled = false;
                //Cargar escena You Win Bitch
            }
        }
        
        
    }
}
